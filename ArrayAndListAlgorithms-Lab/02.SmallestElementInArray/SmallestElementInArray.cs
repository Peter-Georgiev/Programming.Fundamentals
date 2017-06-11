using System;
using System.Linq;

class SmallestElementInArray
{
    static void Main()
    {
        int[] readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int minValue = int.MaxValue;

        for (int i = 0; i < readLine.Length; i++)
        {
            if (readLine[i] < minValue)
            {
                minValue = readLine[i];
            }
        }
        
        Console.WriteLine(minValue);
    }
}