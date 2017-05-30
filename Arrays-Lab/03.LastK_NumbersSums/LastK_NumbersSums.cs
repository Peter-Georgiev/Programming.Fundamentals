using System;

class LastK_NumbersSums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        long[] seq = new long[n];
        seq[0] = 1;

        for (int i = 1; i < n; i++)
        {
            long sum = 0;

            for (int i2 = i - k ; i2 <= i - 1; i2++)
            {
                if (i2 >= 0)
                {
                    sum += seq[i2];
                }

                seq[i] = sum;
            }            
        }

        foreach (var printSeq in seq)
        {
            Console.Write($"{printSeq} ");
        }

        Console.WriteLine();
    }
}