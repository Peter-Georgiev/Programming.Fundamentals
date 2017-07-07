using System;
using System.Collections.Generic;
using System.Linq;

class KeyKeyValueValue
{
    static void Main()
    {
        var dictionary = new Dictionary<string, List<string>>();

        string key = Console.ReadLine();
        string value = Console.ReadLine();

        InsertDictionary(dictionary);

        PrintResult(dictionary, key, value);
    }

    private static void PrintResult(Dictionary<string, List<string>> dictionary, string key, string value)
    {
        var keyEqual = dictionary
            .Where(x => x.Key.Contains(key))
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var kvp in keyEqual)
        {
            Console.WriteLine($"{kvp.Key}:");

            foreach (var item in kvp.Value)
            {
                if (item.Contains(value))
                {
                    Console.WriteLine($"-{item}");
                }
            }
        }
    }

    private static void InsertDictionary(Dictionary<string, List<string>> dictionary)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(" =>;".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int token = 1; token < tokens.Length; token++)
            {
                if (!dictionary.ContainsKey(tokens[0]))
                {
                    dictionary.Add(tokens[0], new List<string>());
                }

                dictionary[tokens[0]].Add(tokens[token]);
            }
        }
    }
}