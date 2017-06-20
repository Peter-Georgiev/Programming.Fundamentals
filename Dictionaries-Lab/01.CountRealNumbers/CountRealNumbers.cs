using System;
using System.Linq;
using System.Collections.Generic;

class CountRealNumbers
{
    static void Main()
    {
        List<double> readLine = Console.ReadLine()
            .Split(' ')
            .Select(double.Parse)
            .ToList();

        SortedDictionary<double, int> printResult = new SortedDictionary<double, int>();

        foreach (var print in readLine)
        {
            if (!printResult.ContainsKey(print))
            {
                printResult[print] = 0;
            }

            printResult[print]++;
        }

        foreach (var print in printResult)
        {
            Console.WriteLine($"{print.Key} -> {print.Value}");
        }
    }
}