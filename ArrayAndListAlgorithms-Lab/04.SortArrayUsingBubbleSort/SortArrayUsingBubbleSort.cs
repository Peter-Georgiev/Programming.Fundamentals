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

        bool isSwapped = false;

        do
        {
            isSwapped = false;

            for (int i = 0; i < readLine.Length - 1; i++)
            {
                var current = readLine[i];
                var next = readLine[i + 1];

                if (current > next)
                {
                    var temp = current;
                    readLine[i + 1] = current;
                    readLine[i] = next;

                    isSwapped = true;
                }
            }

        } while (isSwapped);

        Console.WriteLine(string.Join(" ", readLine));
    }
}