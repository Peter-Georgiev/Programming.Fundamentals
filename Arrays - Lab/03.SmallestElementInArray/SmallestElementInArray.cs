using System;
using System.Linq;

class SmallestElementInArray
{
    static void Main()
    {
        int[] readLine = ReadLine();

        PrintSmallestElement(readLine);
    }

    static int[] ReadLine()
    {
        int[] readLine = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
        return readLine;
    }

    static void PrintSmallestElement(int[] readLine)
    {
        int minElements = int.MaxValue;

        for (int i = 0; i < readLine.Length; i++)
        {
            if (readLine[i] < minElements)
            {
                minElements = readLine[i];
            }
        }

        Console.WriteLine(minElements);
    }
}