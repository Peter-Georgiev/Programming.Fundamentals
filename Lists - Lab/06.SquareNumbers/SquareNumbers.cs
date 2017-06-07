using System;
using System.Collections.Generic;
using System.Linq;

class SquareNumbers
{
    static void Main()
    {
        int[] squareNums = Console.ReadLine()
            .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        List<int> printSquareNums = new List<int>(squareNums.Length);

        for (int i = 0; i < squareNums.Length; i++)
        {
            if ((int)Math.Sqrt(squareNums[i]) == (double)Math.Sqrt(squareNums[i]))
            {
                printSquareNums.Add(squareNums[i]);
            }
        }

        printSquareNums.Sort((a, b) => b.CompareTo(a));

        Console.WriteLine(string.Join(" ", printSquareNums));
    }
}