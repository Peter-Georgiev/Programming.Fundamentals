using System;
using System.Collections.Generic;
using System.Linq;

class SumAdjacentEqualNumbers
{
    static void Main()
    {
        List<double> inputInteger = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(Double.Parse)
            .ToList();

        byte count = 0;
        while (count < inputInteger.Count - 1)
        {
            if (inputInteger[count] == inputInteger[count + 1])
            {
                inputInteger[count] *= 2;
                inputInteger.RemoveAt(count + 1);
                if (count > 0)
                {
                    count--;
                }
            }
            else
            {
                count++;
            }
        }

        Console.WriteLine(string.Join(" ", inputInteger));
    }
}