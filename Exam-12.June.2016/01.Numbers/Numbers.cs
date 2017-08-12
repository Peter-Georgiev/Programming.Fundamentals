using System;
using System.Collections.Generic;
using System.Linq;

class Numbers
{
    static void Main()
    {
        int[] input = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        List<int> topFive = new List<int>();

        double average = input.Average();

        if (average == input.Max())
        {
            Console.WriteLine("No");
            return;
        }
        
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] > average)
            {
                topFive.Add(input[i]);
            }
        }

        Console.WriteLine(String.Join(" ", topFive.OrderByDescending(x => x).Take(5)));
    }
}