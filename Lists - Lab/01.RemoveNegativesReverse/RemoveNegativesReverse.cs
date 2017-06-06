using System;
using System.Collections.Generic;
using System.Linq;

class RemoveNegativesReverse
{
    static void Main()
    {
        List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        input.RemoveAll(i => i < 0);
        
        if (input.Count == 0)
        {
            Console.WriteLine("empty");
        }
        else
        {
            input.Reverse();
            Console.WriteLine(string.Join(" ", input));
        }
    }
}