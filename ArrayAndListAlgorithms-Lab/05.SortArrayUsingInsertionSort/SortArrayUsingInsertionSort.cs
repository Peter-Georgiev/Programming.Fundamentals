using System;
using System.Linq;

class SortArrayUsingInsertionSort
{
    static void Main()
    {
        int[] readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        for(int i = 1; i < readLine.Length; i++)
        {
            var current = readLine[i];
            var previous = i - 1;

            while (previous >= 0 && readLine[previous] > current)
            {
                readLine[previous + 1] = readLine[previous];

                previous--;
            }

            readLine[previous + 1] = current;
        }

        Console.WriteLine(string.Join(" ", readLine));
    }
}