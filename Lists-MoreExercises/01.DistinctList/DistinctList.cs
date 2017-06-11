using System;
using System.Collections.Generic;
using System.Linq;

class DistinctList
{
    static void Main()
    {
        var firstLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        RemoveEqualInteger(firstLine);
    }

    private static void RemoveEqualInteger(List<int> firstLine)
    {
        for (int i = 0; i < firstLine.Count; i++)
        {
            byte count = 0;
            for (int j = i; j < firstLine.Count; j++)
            {
                if (firstLine[i] == firstLine[j])
                {
                    count++;
                    if (count > 1)
                    {
                        firstLine.RemoveAt(j);
                        j--;
                    }
                }
            }
        }

        Console.WriteLine(string.Join(" ", firstLine));
    }
}