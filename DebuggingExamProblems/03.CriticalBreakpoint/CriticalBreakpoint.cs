using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Line
{
    public int X1 { get; set; }

    public int Y1 { get; set; }

    public int X2 { get; set; }

    public int Y2 { get; set; }

    public long CriticalRatio { get; set; }
}

class CriticalBreakpoint
{
    static void Main()
    {
        List<Line> lines = new List<Line>();

        ReadLine(lines);

        bool hasBreakpoint;
        BigInteger actualRatio;

        GetBreakpoint(lines, out hasBreakpoint, out actualRatio);

        PrintBreakpoint(lines, hasBreakpoint, actualRatio);
    }

    static void PrintBreakpoint(List<Line> lines, bool hasBreakpoint, BigInteger actualRatio)
    {
        if (hasBreakpoint)
        {
            BigInteger totalRatio = BigInteger.Pow(actualRatio, lines.Count);
            totalRatio = totalRatio % lines.Count;

            foreach (var l in lines)
            {
                Console.WriteLine($"Line: [{l.X1}, {l.Y1}, {l.X2}, {l.Y2}]");
            }
            Console.WriteLine($"Critical Breakpoint: {totalRatio}");
        }
        else
        {
            Console.WriteLine("Critical breakpoint does not exist.");
        }
    }

    static void GetBreakpoint(List<Line> lines, out bool hasBreakpoint, out BigInteger actualRatio)
    {
        hasBreakpoint = true;
        actualRatio = 0;
        foreach (var line in lines)
        {
            if (actualRatio == 0 && line.CriticalRatio != 0)
            {
                actualRatio = line.CriticalRatio;
            }

            if (line.CriticalRatio != actualRatio && line.CriticalRatio != 0)
            {
                hasBreakpoint = false;
                break;
            }
        }
    }

    static void ReadLine(List<Line> lines)
    {
        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("Break it."))
            {
                break;
            }

            int[] input = readLine
                .Split()
                .Select(int.Parse)
                .ToArray();

            Line newLine = new Line()
            {
                X1 = input[0],
                Y1 = input[1],
                X2 = input[2],
                Y2 = input[3],
                CriticalRatio = Math.Abs
                (((long)input[2] + input[3]) - ((long)input[0] + input[1]))
            };

            lines.Add(newLine);
        }
    }
}