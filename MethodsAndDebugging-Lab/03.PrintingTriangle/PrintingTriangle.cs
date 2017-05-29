using System;

class PrintingTriangle
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        PrintTriagle(number);
    }

    public static void PrintTriagle(int n)
    {
        for (int row = 1; row <= n; row++)
        {
            PrintLine(1, row);
        }

        for (int row = n - 1; row >= 1; row--)
        {
            PrintLine(1, row);
        }
    }

    private static void PrintLine(int start, int end)
    {
        for (int col = start; col <= end; col++)
        {
            Console.Write($"{col} ");
        }
        Console.WriteLine();
    }
}
