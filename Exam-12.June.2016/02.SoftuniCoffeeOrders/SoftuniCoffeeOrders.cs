using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

class SoftuniCoffeeOrders
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<decimal> result = new List<decimal>();

        for (int i = 0; i < n; i++)
        {
            decimal capsule = decimal.Parse(Console.ReadLine());
            int[] data = Console.ReadLine()
                .Split('/')
                .Select(int.Parse)
                .ToArray();
            long count = long.Parse(Console.ReadLine());
            int days = DateTime.DaysInMonth(data[2], data[1]);

            result.Add(((days * count) * capsule));
        }

        foreach (var r in result)
        {
            Console.WriteLine($"The price for the coffee is: ${r:F2}");
        }

        Console.WriteLine($"Total: ${result.Sum():F2}");
    }
}