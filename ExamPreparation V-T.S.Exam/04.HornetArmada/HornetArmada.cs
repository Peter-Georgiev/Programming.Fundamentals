using System;
using System.Collections.Generic;
using System.Linq;

class HornetArmada
{
    static void Main()
    {
        Dictionary<string, int> legionActivityData = new Dictionary<string, int>();
        Dictionary<string, Dictionary<string, long>> soldiersNameTypeCountData = 
            new Dictionary<string, Dictionary<string, long>>();
        
        InsertSoldier(legionActivityData, soldiersNameTypeCountData);

        string[] command = Console.ReadLine()
            .Split(new[] { '\\' },
            StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        if (command.Length.Equals(2))
        {
            PrintActivitySoldierType(command, soldiersNameTypeCountData, legionActivityData);
        }
        else
        {
            PrinterSoldierType(command, soldiersNameTypeCountData, legionActivityData);
        }
    }

    static void PrintActivitySoldierType(string[] command, Dictionary<string, Dictionary<string, long>> soldiersNameTypeCountData, Dictionary<string, int> legionActivityData)
    {
        int activity = int.Parse(command[0]);
        string type = command[1];

        foreach (var kvp in soldiersNameTypeCountData
            .Where(x => x.Value.ContainsKey(type))
            .OrderByDescending(x => x.Value[type]))
        {
            string legionName = kvp.Key;

            if (legionActivityData[legionName] < activity)
            {
                Console.WriteLine($"{legionName} -> {kvp.Value[type]}");        
            }
        }
    }

    static void PrinterSoldierType(string[] command, Dictionary<string, Dictionary<string, long>> soldiersNameTypeCountData, Dictionary<string, int> legionActivityData)
    {
        string type = command[0];

        foreach (var kvp in legionActivityData.OrderByDescending(x => x.Value))
        {
            if (soldiersNameTypeCountData[kvp.Key].ContainsKey(type))
            {
                Console.WriteLine($"{kvp.Value} : {kvp.Key}");
            }
        }
    }

    static void InsertSoldier(Dictionary<string, int> legionActivityData, Dictionary<string, Dictionary<string, long>> soldiersNameTypeCountData)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(new string[] { " = ", " -> ", ":" },
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int lastActivity = int.Parse(input[0]);
            string legionName = input[1];
            string soldierType = input[2];
            int soldierCount = int.Parse(input[3]);

            if (!legionActivityData.ContainsKey(legionName))
            {
                legionActivityData.Add(legionName, lastActivity);
                soldiersNameTypeCountData.Add(legionName,
                    new Dictionary<string, long>());
            }

            if (!soldiersNameTypeCountData[legionName].ContainsKey(soldierType))
            {
                soldiersNameTypeCountData[legionName].Add(soldierType, 0);
            }

            if (legionActivityData[legionName] < lastActivity)
            {
                legionActivityData[legionName] = lastActivity;
            }

            soldiersNameTypeCountData[legionName][soldierType] += soldierCount;
        }
    }
}