using System;
using System.Linq;

class CountOccurrenOfLargerNumArray
{
    static void Main()
    {
        float[] arrayOfRealNums = Console.ReadLine().Split(' ').Select(float.Parse).ToArray();
        float n = float.Parse(Console.ReadLine());

        int count = 0;
        for (int i = 0; i < arrayOfRealNums.Length; i++)
        {
            if (n < arrayOfRealNums[i])
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}