using System;
using System.Collections.Generic;
using System.Linq;

class NSA
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> nsa =
            new Dictionary<string, Dictionary<string, int>>();

        InsertNSA(nsa);

        PrintResult(nsa);
    }

    private static void InsertNSA(Dictionary<string, Dictionary<string, int>> nsa)
    {
        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("quit"))
            {
                break;
            }

            string[] tokens = readLine
                .Split(new string[] { " -> " },
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string country = tokens[0];
            string spy = tokens[1];
            int days = int.Parse(tokens[2]);

            if (!nsa.ContainsKey(country))
            {
                nsa.Add(country, new Dictionary<string, int>());
            }

            if (!nsa[country].ContainsKey(spy))
            {
                nsa[country].Add(spy, 0);
            }

            nsa[country][spy] = days;
        }
    }

    private static void PrintResult(Dictionary<string, Dictionary<string, int>> nsa)
    {
        foreach (var kvp in nsa.OrderByDescending(x => x.Value.Count))
        {
            Console.WriteLine($"Country: {kvp.Key}");

            foreach (var s in kvp.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"**{s.Key} : {s.Value}");
            }
        }
    }
}