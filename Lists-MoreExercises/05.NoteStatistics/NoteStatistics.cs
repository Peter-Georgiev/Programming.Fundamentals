using System;
using System.Collections.Generic;
using System.Linq;

class NoteStatistics
{
    static void Main()
    {
        double[] readLine = ReadLine();

        PrintResult(readLine);
    }

    private static double[] Frequency()
    {
        double[] frequency = new double[]
        { 261.63, 277.18, 293.66, 311.13, 329.63, 349.23, 369.99,
        392.00, 415.30, 440.00, 466.16, 493.88 };

        return frequency;
    }

    private static string[] Note()
    {
        string[] note = new string[]
        { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

        return note;
    }

    private static double[] ReadLine()
    {
        double[] readLine = Console.ReadLine()
            .Split(' ')
            .Select(double.Parse)
            .ToArray();

        return readLine;
    }

    private static List<string> GetResultBody(double[] readLine, byte command)
    {
        List<string> getResult = new List<string>(readLine.Length);
        List<double> sum = new List<double>(readLine.Length);
        bool isSum = false;

        for (int r = 0; r < readLine.Length; r++)
        {
            for (int f = 0; f < Frequency().Length; f++)
            {
                if (Frequency()[f] == readLine[r])
                {
                    if (command.Equals(0))
                    {
                        getResult.Add(Note()[f]);
                    }
                    else if (command.Equals(1))
                    {
                        if (Note()[f].Length == 1)
                        {
                            getResult.Add(Note()[f]);
                        }
                    }
                    else if (command.Equals(2))
                    {
                        if (Note()[f].Length == 2)
                        {
                            getResult.Add(Note()[f]);
                        }
                    }
                    else if (command.Equals(3))
                    {
                        if (Note()[f].Length == 1)
                        {
                            sum.Add(Frequency()[f]);
                            isSum = true;
                        }
                    }
                    else if (command.Equals(4))
                    {
                        if (Note()[f].Length == 2)
                        {
                            sum.Add(Frequency()[f]);
                            isSum = true;
                        }
                    }
                }
            }
        }

        if (isSum)
        {
            string getSum = Convert.ToString(sum.Sum());
            getResult.Add(getSum);
        }
        else if (sum.Count.Equals(0) && (command.Equals(3) || command.Equals(4)))
        {
            getResult.Add("0");
        }

        return getResult;
    }

    private static void PrintResult(double[] readLine)
    {
        var printResult = new List<string>();

        for (byte i = 0; i < 5; i++)
        {
            if (i == 0)
            {
                Console.WriteLine($"Notes: {string.Join(" ", GetResultBody(readLine, i))}");
            }
            else if (i == 1)
            {
                Console.WriteLine($"Naturals: {string.Join(", ", GetResultBody(readLine, i))}");
            }
            else if (i == 2)
            {
                Console.WriteLine($"Sharps: {string.Join(", ", GetResultBody(readLine, i))}");
            }
            else if (i == 3)
            {
                Console.WriteLine($"Naturals sum: {string.Join("", GetResultBody(readLine, i))}");
            }
            else if (i == 4)
            {
                Console.WriteLine($"Sharps sum: {string.Join("", GetResultBody(readLine, i))}");
            }
        }
    }
}