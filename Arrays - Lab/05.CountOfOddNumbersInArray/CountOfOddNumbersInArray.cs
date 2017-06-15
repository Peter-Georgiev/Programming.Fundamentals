using System;
using System.Linq;

class CountOfOddNumbersInArray
{
    static void Main()
    {
        int[] readLine = ReadLine();

        byte count = 0;

        for (int i = 0; i < readLine.Length; i++)
        {
            if (readLine[i] % 2 != 0)
            {
                count++;
            }
        }

        Console.WriteLine(count);
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