using System;
using System.Collections.Generic;
using System.Linq;

class LINQuistics
{
    static void Main()
    {
        var baseCollections = new Dictionary<string, HashSet<string>>();
        string readLine = String.Empty;

        while (true)
        {
            readLine = Console.ReadLine();

            if (readLine.Equals("exit"))
            {
                readLine = Console.ReadLine();
                PrintCommandExit(baseCollections, readLine);
                break;
            }
            else if (int.TryParse(readLine, out int n))
            {
                PrintCommandDigit(baseCollections, n);
            }
            else if (baseCollections.ContainsKey(readLine))
            {
                PrintCommandCollection(baseCollections, readLine);
            }
            else
            {
                InsertCollectionAndMethod(baseCollections, readLine);
            }
        }
    }

    private static void PrintCommandExit(Dictionary<string, HashSet<string>> baseCollections, string readLine)
    {
        string[] tokens = readLine
            .Split(' ')
            .ToArray();
        string method = tokens[0];
        string selection = tokens[1];

        var result = baseCollections
            .Where(x => x.Value.Contains(method))
            .OrderByDescending(x => x.Value.Count)
            .ThenByDescending(x => x.Value.Min(m => m.Length));

        foreach (var kvp in result)
        {
            Console.WriteLine(kvp.Key);

            if (selection.Equals("all"))
            {
                var list = kvp.Value
                    .OrderByDescending(x => x.Length)
                    .ToList();

                PrintResult(list);
            }
        }
    }

    private static void PrintResult(List<string> list)
    {
        foreach (var print in list)
        {
            Console.WriteLine("* {0}", print);
        }
    }

    private static void PrintCommandDigit(Dictionary<string, HashSet<string>> baseCollections, int n)
    {
        if (baseCollections.Count > 0)
        {
            var list = baseCollections.Values
                .First(x => x.Count == baseCollections.Values.Max(m => m.Count))
                .OrderBy(x => x.Length)
                .Take(n)
                .ToList();

            PrintResult(list);
        }
    }

    private static void PrintCommandCollection(Dictionary<string, HashSet<string>> baseCollections, string readLine)
    {
        var print = baseCollections[readLine]
            .OrderByDescending(x => x.Length)
            .ThenByDescending(x => x.Distinct().Count())
            .ToList();

        PrintResult(print);
    }

    private static void InsertCollectionAndMethod(Dictionary<string, HashSet<string>> baseCollections, string readLine)
    {
        string[] tokens = readLine
            .Split(".()".ToCharArray(),
            StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        if (tokens.Length > 1)
        {            
            string collection = tokens[0];

            if (!baseCollections.ContainsKey(collection))
            {
                baseCollections.Add(collection, new HashSet<string>());
            }

            for (int i = 1; i < tokens.Length; i++)
            {
                baseCollections[collection].Add(tokens[i]);
            }
        }
    }    
}