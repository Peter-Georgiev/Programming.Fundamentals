using System;
using System.Collections.Generic;
using System.Linq;

class ShoppingSpree
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, string>> flattenDictionary =
            new Dictionary<string, Dictionary<string, string>>();

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.ToLower().Equals("end"))
            {
                break;
            }

            string[] input = readLine
                .Split(' ')
                .ToArray();

            if (!input[0].Equals("flatten"))
            {
                string key = input[0];
                string innerKeys = input[1];
                string innerValue = input[2];

                if (!flattenDictionary.ContainsKey(key))
                {
                    flattenDictionary.Add(key, new Dictionary<string, string>());
                    flattenDictionary[key][innerKeys] = innerValue;
                }
                else
                {
                    flattenDictionary[key][innerKeys] = innerValue;
                }
            }
            else
            {
                string key = input[1];

                flattenDictionary[key] = flattenDictionary[key]
                    .ToDictionary(x => x.Key + x.Value, x => "flattened");
            }
        }

        var orderedDictionary = flattenDictionary
            .OrderByDescending(x => x.Key.Length)
            .ToDictionary(x => x.Key, x => x.Value);

        byte count = 0;
        foreach (var print in orderedDictionary)
        {
            Console.WriteLine("{0}", print.Key);

            
            count++;
        }


    }
}