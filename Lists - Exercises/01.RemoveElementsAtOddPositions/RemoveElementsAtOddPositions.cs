using System;
using System.Collections.Generic;
using System.Linq;

class RemoveElementsAtOddPositions
{
    static void Main()
    {
        var inputStr = Console.ReadLine().Split(' ').ToList();
        var printStr = new List<string>(inputStr.Count);

        for (int i = 1; i <= inputStr.Count; i++)
        {
            if (i % 2 == 0)
            {
                printStr.Add(inputStr[i - 1]);
            }
        }

        printStr.ForEach(Console.Write);
        Console.WriteLine();
    }
}