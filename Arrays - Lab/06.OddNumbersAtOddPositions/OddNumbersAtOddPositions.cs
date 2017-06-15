using System;
using System.Linq;

class OddNumbersAtOddPositions
{
    static void Main()
    {
        int[] readLine = ReadLine();

        byte count = 0;

        for (int i = 0; i < readLine.Length; i++)
        {
            if (readLine[i] % 2 != 0 && i % 2 != 0)
            {
                Console.WriteLine($"Index {i} -> {readLine[i]}");
            }
        }
    }

    static int[] ReadLine()
    {
        int[] readLine = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
        return readLine;
    }
}