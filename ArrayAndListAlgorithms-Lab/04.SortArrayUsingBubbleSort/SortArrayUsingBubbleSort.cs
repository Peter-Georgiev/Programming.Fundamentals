using System;
using System.Linq;

class SortArrayUsingBubbleSort
{
    static void Main()
    {
        int[] readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        bool isSwapped;

        do
        {
            isSwapped = false;

            for (int i = 0; i < readLine.Length - 1; i++)
            {
                int current = readLine[i];
                int next = readLine[i + 1];

                if (current > next)
                {
                    readLine[i + 1] = current;
                    readLine[i] = next;
                    isSwapped = true;
                }
            }

        } while (isSwapped);

        foreach (var print in readLine)
        {
            Console.Write($"{print} ");
        }
    }
}