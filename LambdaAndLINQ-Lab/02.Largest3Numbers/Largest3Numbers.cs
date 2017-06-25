using System;
using System.Collections.Generic;
using System.Linq;

class Largest3Numbers
{
    static void Main()
    {
        var nums = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(n => double.Parse(n))
            .ToList();

        var resultNums = nums
            .OrderByDescending(n => n)
            .Take(3);

        Console.WriteLine(string.Join(" ", resultNums));
    }
}