using System;
using System.Collections.Generic;
using System.Linq;

class Camping
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, byte>> dictionary =
            new Dictionary<string, Dictionary<string, byte>>();

        InsertPeople(dictionary);

        PrintResult(dictionary);
    }

    private static void PrintResult(Dictionary<string, Dictionary<string, byte>> dictionary)
    {
        var sort = dictionary
            .OrderByDescending(x => x.Value.Count)
            .ThenBy(x => x.Key.Length)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var kvp in sort)
        {
            Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value.Keys.Count());

            kvp.Value
                .ToList()
                .ForEach(x => Console.WriteLine("***{0}", x.Key));

            Console.WriteLine("Total stay: {0} nights", kvp.Value.Sum(x => x.Value));
        }
    }

    private static void InsertPeople(Dictionary<string, Dictionary<string, byte>> dictionary)
    {
        while (true)
        {
            string[] readLine = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (readLine[0].Equals("end"))
            {
                break;
            }
        
             byte timeToStay = byte.Parse(readLine[2]);

            if (!dictionary.ContainsKey(readLine[0]))
            {
                dictionary.Add(readLine[0], new Dictionary<string, byte>());
            }

            if (!dictionary[readLine[0]].ContainsKey(readLine[1]))
            {
                dictionary[readLine[0]].Add(readLine[1], timeToStay);
            }
            else
            {
                dictionary[readLine[0]][readLine[1]] = timeToStay;
            }
        }
    }
}