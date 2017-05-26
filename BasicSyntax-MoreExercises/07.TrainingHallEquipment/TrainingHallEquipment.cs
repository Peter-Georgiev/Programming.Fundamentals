using System;
using System.Collections.Generic;

class TrainingHallEquipment
{
    static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        int numberItems = int.Parse(Console.ReadLine()) * 3;
        string[] items = new string[numberItems];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = Console.ReadLine();
        }

        double allSum = 0.00d;
        for (int i = 1; i <= items.Length - 2; i += 3)
        {
            allSum += double.Parse(items[i]) * int.Parse(items[i + 1]);
        }

        List<string> printItems = new List<string>();
        for (int i = 0; i < items.Length - 2; i += 3)
        {
            if (Convert.ToInt32(items[i + 2]) > 1)
            {
                printItems.Add($"Adding {items[i + 2]} {items[i] + 's'} to cart.");
            }
            else
            {
                printItems.Add($"Adding {items[i + 2]} {items[i]} to cart.");
            }
        }

        foreach (var item in printItems)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine($"Subtotal: ${allSum:F2}");

        if (budget >= allSum)
        {
            Console.WriteLine($"Money left: ${budget - allSum:F2}");
        }
        else
        {
            Console.WriteLine($"Not enough. We need ${allSum - budget:F2} more.");
        }
    }
}