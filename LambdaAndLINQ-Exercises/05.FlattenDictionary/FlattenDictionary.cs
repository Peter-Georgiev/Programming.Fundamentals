using System;
using System.Collections.Generic;
using System.Linq;

class FlattenDictionary
{
    static void Main()
    {
        var dictionary =
            new Dictionary<string, Dictionary<string, string>>();

        InsertKeyInnerKeyAndValue(dictionary);

        PrintResult(dictionary);
    }

    private static void InsertKeyInnerKeyAndValue(Dictionary<string, Dictionary<string, string>> dictionary)
    {
        while (true)
        {
            string[] tokens = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            if (tokens[0].Equals("end"))
            {
                break;
            }
            else if (tokens[0].Equals("flatten"))
            {
                string key = tokens[1];
                dictionary[key] = dictionary[key]
                .ToDictionary(x => x.Key + x.Value, x => "flatened");
            }
            else
            {
                if (!dictionary.ContainsKey(tokens[0]))
                {
                    dictionary.Add(tokens[0], new Dictionary<string, string>());
                    dictionary[tokens[0]][tokens[1]] = tokens[2];
                }
                else
                {
                    dictionary[tokens[0]][tokens[1]] = tokens[2];
                }
            }
        }
    }

    private static void PrintResult(Dictionary<string, Dictionary<string, string>> dictionary)
    {
        var orderedDictionary = dictionary
                .OrderByDescending(x => x.Key.Length)
                .ToDictionary(x => x.Key, x => x.Value);

        foreach (var kvpKey in orderedDictionary)
        {
            Console.WriteLine(kvpKey.Key);
            byte count = 1;

            var orderedInnerDictionary = kvpKey.Value
                .Where(x => x.Value != "flatened")
                .OrderBy(x => x.Key.Length)
                .ToDictionary(x => x.Key, x => x.Value);

            var flatenedValue = kvpKey.Value
               .Where(x => x.Value.Equals("flatened"))
               .ToDictionary(x => x.Key, x => x.Value);

            foreach (var innerKvp in orderedInnerDictionary)
            {
                Console.WriteLine($"{count++}. {innerKvp.Key} - {innerKvp.Value}");
            }

            foreach (var flatenedKvp in flatenedValue)
            {
                Console.WriteLine($"{count++}. {flatenedKvp.Key}");
            }
        }
    }
}