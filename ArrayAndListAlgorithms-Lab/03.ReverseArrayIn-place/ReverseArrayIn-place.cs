using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int halfArr = readLine.Length / 2;

        for (int i = 0; i < halfArr; i++)
        {
            int temp = readLine[i];
            readLine[i] = readLine[(readLine.Length - 1) - i];
            readLine[(readLine.Length - 1) - i] = temp;
        }

        foreach (var print in readLine)
        {
            Console.Write($"{print} ");
        }
    }
}