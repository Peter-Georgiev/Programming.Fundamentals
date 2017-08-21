using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class Trainlands
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> data =
            new Dictionary<string, Dictionary<string, int>>();

        string readLine;
        while ((readLine = Console.ReadLine()) != "It's Training Men!")
        {
            Match regex = Regex.Match(readLine, @"(^.+) -> (.+) : (\d+$)");
            
            if (regex.Success)
            {
                InsertTrain(data, regex);
            }

            string trainName = String.Empty;
            string otherTrainName = String.Empty;

            regex = Regex.Match(readLine, @"^(\w+) -> (\w+)$");
            if (regex.Success)
            {
                trainName = regex.Groups[1].Value;
                otherTrainName = regex.Groups[2].Value;

                if (!data.ContainsKey(trainName))
                {
                    data.Add(trainName, new Dictionary<string, int>());
                }

                foreach (var kvp in data)
                {
                    if (kvp.Key == otherTrainName)
                    {
                        foreach (var w in kvp.Value)
                        {
                            if (!data[trainName].ContainsKey(w.Key))
                            {
                                data[trainName].Add(w.Key, w.Value);
                            }

                            data[trainName][w.Key] = w.Value;
                        }
                    }
                }
                data.Remove(otherTrainName);
            }

            regex = Regex.Match(readLine, @"^(\w+) = (\w+)$");
            if (regex.Success)
            {
                trainName = regex.Groups[1].Value;
                otherTrainName = regex.Groups[2].Value;

                if (!data.ContainsKey(trainName))
                {
                    data.Add(trainName, new Dictionary<string, int>());
                }            
                data[trainName] = new Dictionary<string, int>();

                foreach (var kvp in data)
                {
                    if (kvp.Key == otherTrainName)
                    {
                        foreach (var w in kvp.Value)
                        {
                            if (!data[trainName].ContainsKey(w.Key))
                            {
                                data[trainName].Add(w.Key, w.Value);
                            }

                            data[trainName][w.Key] = w.Value;
                        }
                    }
                }
            }
        }
        


        foreach (var kvp in data.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Count()))
        {
            Console.WriteLine($"Train: { kvp.Key}");

            foreach (var w in kvp.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"###{w.Key} - {w.Value}");
            }
        }

    }

    private static void InsertTrain(Dictionary<string, Dictionary<string, int>> data, Match regex)
    {
        string trainName = regex.Groups[1].Value;
        string wagonName = regex.Groups[2].Value;
        int wagonPower = int.Parse(regex.Groups[3].Value);

        if (!data.ContainsKey(trainName))
        {
            data.Add(trainName, new Dictionary<string, int>());
        }

        if (!data[trainName].ContainsKey(wagonName))
        {
            data[trainName].Add(wagonName, wagonPower);
        }
    }
}