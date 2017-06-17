using System;
using System.Linq;

class SortArrayOfStrings
{
    static void Main()
    {
        string[] readLine = ReadLine();

        readLine = SortStringBubbleSort(readLine);

        PrintResult(readLine);
    }

    static string[] ReadLine()
    {
        string[] readLine = Console.ReadLine()
            .Split(' ')
            .ToArray();

        return readLine;
    }

    static string[] SortStringBubbleSort(string[] readLine)
    {
        bool isSwapped = false;

        do
        {
            isSwapped = false;

            for (int i = 0; i < readLine.Length - 1; i++)
            {
                var current = readLine[i];
                var next = readLine[i + 1];

                var compare = next.CompareTo(current);

                if (compare < 0)
                {
                    var temp = next;
                    readLine[i + 1] = current;
                    readLine[i] = temp;
                    isSwapped = true;
                }
            }

        } while (isSwapped);

        return readLine;
    }

    static void PrintResult(string[] sortString)
    {
        Console.WriteLine(string.Join(" ", sortString));
    }
}