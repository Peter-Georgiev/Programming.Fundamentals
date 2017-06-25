using System;
using System.Collections.Generic;
using System.Linq;

class FoldAndSum
{
    static void Main()
    {
        var nums = Console.ReadLine()
            .Split(' ')
            .Select(n => int.Parse(n))
            .ToArray();

        var k = nums.Length / 4;

        var firstPartUpperRow = nums
            .Take(k)
            .Reverse()
            .ToArray();

        var secondPartUpperRow = nums
            .Reverse()
            .Take(k);

        var upperRow = firstPartUpperRow
            .Concat(secondPartUpperRow)
            .ToArray();

        var lowerRow = nums
            .Skip(k)
            .Take(2 * k)
            .ToArray();

        var result = upperRow
            .Select((n, index) => n + lowerRow[index]);

        //var result = new int[upperRow.Length];

        //for (int i = 0; i < upperRow.Length; i++)
        //{
        //    result[i] = upperRow[i] + lowerRow[i];
        //}

        Console.WriteLine(string.Join(" ", result));
    }
}