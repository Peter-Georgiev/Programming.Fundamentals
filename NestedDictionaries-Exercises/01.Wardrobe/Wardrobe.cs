using System;
using System.Collections.Generic;
using System.Linq;

class Wardrobe
{
    static void Main()
    {
        var dictionari = new Dictionary<string, Dictionary<string, int>>();

        byte n = byte.Parse(Console.ReadLine());

        InsertColor(dictionari, n);

        PrintResult(dictionari);
    }

    private static void PrintResult(Dictionary<string, Dictionary<string, int>> dictionary)
    {
        string[] tokens = Console.ReadLine()
                .Split(" ,".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"{kvp.Key} clothes:");

            foreach (var item in kvp.Value)
            {
                string found = String.Empty;

                if (kvp.Key.Equals(tokens[0]) && item.Key.Equals(tokens[1]))
                {
                    found = "(found!)";
                }
                Console.WriteLine($"* {item.Key} - {item.Value} {found}");
            }
        }
    }

    private static void InsertColor(Dictionary<string, Dictionary<string, int>> dictionari, byte n)
    {
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(" ,".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (!dictionari.ContainsKey(tokens[0]))
            {
                dictionari.Add(tokens[0], new Dictionary<string, int>());
            }

            if (!dictionari[tokens[0]].ContainsKey(tokens[1]))
            {
                for (int read = 2; read < tokens.Length; read++)
                {
                    dictionari[tokens[0]].Add(tokens[read], 0);
                }
            }

            for (int read = 2; read < tokens.Length; read++)
            {
                dictionari[tokens[0]][tokens[read]]++;
            }
        }
    }
}