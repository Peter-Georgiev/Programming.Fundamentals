using System;

class LargestElementInArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] arrayOfNum = new int[n];
        for (int i = 0; i < arrayOfNum.Length; i++)
        {
            arrayOfNum[i] = int.Parse(Console.ReadLine());
        }

        int max = int.MinValue;
        for (int i = 0; i < arrayOfNum.Length; i++)
        {
            if (arrayOfNum[i] > max)
            {
                max = arrayOfNum[i];
            }
        }

        Console.WriteLine(max);
    }
}