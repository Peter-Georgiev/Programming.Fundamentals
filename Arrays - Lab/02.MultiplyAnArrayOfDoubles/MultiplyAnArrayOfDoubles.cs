using System;
using System.Linq;

class MultiplyAnArrayOfDoubles
{
    static void Main()
    {
        double[] readLine;
        double p;

        ReadLine(out readLine, out p);

        PrintResult(readLine, p);
    }

    static void PrintResult(double[] readLine, double p)
    {
        for (int i = 0; i < readLine.Length; i++)
        {
            readLine[i] *= p;
        }

        Console.WriteLine(string.Join(" ", readLine));
    }

    static void ReadLine(out double[] readLine, out double p)
    {
        readLine = Console.ReadLine()
                    .Split(' ')
                    .Select(double.Parse)
                    .ToArray();

        p = double.Parse(Console.ReadLine());
    }
}