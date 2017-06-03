using System;
using System.Linq;

class SumArrays
{
    static void Main()
    {
        int[] lineArr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] lineArr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        string result = "";
        int maxArray = Math.Max(lineArr1.Length, lineArr2.Length);

        for (int i = 0; i <= maxArray; i++)
        {
            int sum = (lineArr1[i % lineArr1.Length] + lineArr2[i % lineArr2.Length]);

            if (i >= maxArray)
            {
                break;
            }

            result += $"{sum} ";
        }

        Console.WriteLine(result);
    }
}