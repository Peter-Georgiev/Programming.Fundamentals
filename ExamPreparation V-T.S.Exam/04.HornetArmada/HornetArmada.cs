using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class HornetArmada
{
    static void Main()
    {
        Dictionary<string, long> lastActivityData =
            new Dictionary<string, long>();
        Dictionary<string, Dictionary<string, long>> soldierData =
            new Dictionary<string, Dictionary<string, long>>();

        InserData(lastActivityData, soldierData);

        string[] tokens = Console.ReadLine()
            .Split('\\')
            .ToArray();

        if (tokens.Length > 1)
        {
            PrintActivitySoldierType(lastActivityData, soldierData, tokens);
        }
        else
        {
            PrintSoldierType(lastActivityData, soldierData, tokens[0]);
        }
    }

    private static void InserData(Dictionary<string, long> lastActivityData, Dictionary<string, Dictionary<string, long>> soldierData)
    {
        int n = int.Parse(Console.ReadLine());

        while (n > 0)
        {
            Match regex = Regex.Match(Console.ReadLine(),
                @"(?<activity>\d+) = (?<name>.+) -> (?<type>.+):(?<count>\d+)");

            long activity = long.Parse(regex.Groups["activity"].Value);
            string name = regex.Groups["name"].Value;
            string type = regex.Groups["type"].Value;
            long count = long.Parse(regex.Groups["count"].Value);

            if (!lastActivityData.ContainsKey(name))
            {
                lastActivityData.Add(name, activity);
                soldierData.Add(name, new Dictionary<string, long>());
            }

            if (lastActivityData[name] < activity)
            {
                lastActivityData[name] = activity;
            }

            if (!soldierData[name].ContainsKey(type))
            {
                soldierData[name].Add(type, 0);
            }

            soldierData[name][type] += count;

            n--;
        }
    }

    private static void PrintSoldierType(Dictionary<string, long> lastActivityData, Dictionary<string, Dictionary<string, long>> soldierData, string type)
    {
        foreach (var kvp in lastActivityData.OrderByDescending(x => x.Value))
        {
            if (soldierData[kvp.Key].ContainsKey(type))
            {
                Console.WriteLine($"{kvp.Value} : {kvp.Key}");
            }
        }
    }

    private static void PrintActivitySoldierType(Dictionary<string, long> lastActivityData, Dictionary<string, Dictionary<string, long>> soldierData, string[] tokens)
    {
        int activity = int.Parse(tokens[0]);
        string type = tokens[1];

        foreach (var kvp in soldierData.Where(x => x.Value.ContainsKey(type)).OrderByDescending(x => x.Value[type]))
        {
            if (lastActivityData[kvp.Key] < activity)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value[type]}");
            }
        }
    }
}