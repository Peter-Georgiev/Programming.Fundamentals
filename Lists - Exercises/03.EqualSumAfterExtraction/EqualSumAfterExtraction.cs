using System;
using System.Collections.Generic;
using System.Linq;

class EqualSumAfterExtraction
{
    static void Main()
    {
        List<int> firstLine = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        List<int> secondLine = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        for (int i = 0; i < firstLine.Count; i++)
        {
            for (int j = 0; j < secondLine.Count; j++)
            {
                if (firstLine[i] == secondLine[j])
                {
                    secondLine.RemoveAt(j);
                }
            }
        }

        int sumFfirstLine = firstLine.Sum();
        int sumSecondLine = secondLine.Sum();

        if (sumFfirstLine == sumSecondLine)
        {
            Console.WriteLine($"Yes. Sum: {sumFfirstLine}");
        }
        else
        {
            Console.WriteLine($"No. Diff: {Math.Abs(sumFfirstLine - sumSecondLine)}");
        }
    }
}