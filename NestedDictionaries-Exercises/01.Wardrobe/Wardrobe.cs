using System;
using System.Collections.Generic;
using System.Linq;

class Wardrobe
{
    static void Main()
    {
        var dictionary = new Dictionary<string, Dictionary<string, int>>();
        
        InsertColor(dictionary);

        PrintResult(dictionary);
    }

    private static void PrintResult(Dictionary<string, Dictionary<string, int>> dictionary)
    {
        string[] tokens = Console.ReadLine()
                .Split(' ')
                .ToArray();

        foreach (KeyValuePair<string, Dictionary<string, int>> kvp in dictionary)
        {
            string color = kvp.Key;
            Console.WriteLine($"{color} clothes:");

            Dictionary<string, int> clothData = kvp.Value;

            foreach (var item in clothData)
            {
                string cloth = item.Key;
                int quantity = item.Value;

                Console.Write($"* {cloth} - {quantity}");

                if (color == tokens[0] && cloth == tokens[1])
                {
                    Console.Write($" (found!)");
                }

                Console.WriteLine();
            }
        }
    }

    private static void InsertColor(Dictionary<string, Dictionary<string, int>> dictionary)
    {
        int n = int.Parse(Console.ReadLine());

        for (int count = 0; count < n; count++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new string[] { " -> " },
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string color = tokens[0];
            
            if (!dictionary.ContainsKey(color))
            {
                dictionary.Add(color, new Dictionary<string, int>());
            }

            string[] items = tokens[1]
                .Split(',')
                .ToArray();

            foreach (var item in items)
            {
                if (!dictionary[color].ContainsKey(item))
                {
                    dictionary[color].Add(item, 0);
                }

                dictionary[color][item]++;
            }
        }
    }
}