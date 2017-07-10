using System;
using System.Collections.Generic;
using System.Linq;

class TravelCompany
{
    static void Main()
    {
        var company = new Dictionary<string, Dictionary<string, int>>();

        InsertPeoples(company);

        PrintTravelTime(company);
    }

    private static void PrintTravelTime(Dictionary<string, Dictionary<string, int>> company)
    {
        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("travel time!"))
            {
                break;
            }

            string[] tokens = readLine
                .Split(' ')
                .ToArray();

            var cityDic = company
                .Where(x => x.Key.Equals(tokens[0]))
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in cityDic)
            {
                var kvpSum = kvp.Value.Values.Sum();

                if (kvpSum >= int.Parse(tokens[1]))
                {
                    Console.WriteLine($"{tokens[0]} -> all {tokens[1]} accommodated");
                }
                else
                {
                    Console.WriteLine($"{tokens[0]} -> all except " +
                            $"{int.Parse(tokens[1]) - kvpSum} accommodated");
                }
            }
        }
    }

    private static void InsertPeoples(Dictionary<string, Dictionary<string, int>> company)
    {
        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("ready"))
            {
                break;
            }

            string[] tokens = readLine
                .Split(new[] { ':', ',' },
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            
            for (int i = 1; i < tokens.Length; i++)
            {
                string[] typeCapacity = tokens[i].Split('-').ToArray();
                string type = typeCapacity[0];
                int capacity = int.Parse(typeCapacity[1]);

                if (!company.ContainsKey(tokens[0]))
                {
                    company.Add(tokens[0], new Dictionary<string, int>());
                }

                if (!company[tokens[0]].ContainsKey(type))
                {
                    company[tokens[0]].Add(type, capacity);
                }

                company[tokens[0]][type] = capacity;
            }
        }
    }
}