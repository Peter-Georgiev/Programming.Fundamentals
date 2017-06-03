using System;
using System.Linq;

class CountOfGivenElementArray
{
    static void Main()
    {
        int[] arrayOfNum = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int n = int.Parse(Console.ReadLine());

        int count = 0;
        for (int i = 0; i < arrayOfNum.Length; i++)
        {
            if (n == arrayOfNum[i])
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}