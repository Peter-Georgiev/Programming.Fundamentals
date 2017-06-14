using System;
using System.Linq;

class InsertionSortUsingList
{
    static void Main()
    {
        int[] readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        int[] printLine = new int[readLine.Length];

        for (int i = 1; i < readLine.Length; i++)
        {
            var current = readLine[i];
            var previous = i - 1;

            while (previous >= 0 && readLine[previous] > current)
            {
                readLine[previous + 1] = readLine[previous];
                printLine[previous + 1] = readLine[previous];

                previous--;
            }

            readLine[previous + 1] = current;
            printLine[previous + 1] = current;
        }

        Console.WriteLine(string.Join(" ", printLine));
    }
}