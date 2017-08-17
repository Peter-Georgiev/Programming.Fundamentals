using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

class Query
{
    public string Frequency { get; set; }

    public string Recipient { get; set; }

    public string Message { get; set; }
}

class HornetComm
{
    static void Main()
    {
        Dictionary<string, List<Query>> data =
            new Dictionary<string, List<Query>>
            {
                { "broadcast", new List<Query>() },
                { "message", new List<Query>() }
            };
        string readLine;

        while ((readLine = Console.ReadLine()) != "Hornet is Green")
        {
            Match regexBroadcast = Regex.Match(readLine,
                @"(?<message>^[^\d]+) <-> (?<frequency>[0-9A-Za-z]+$)");
            Match regexMessage = Regex.Match(readLine,
                @"(?<recipient>^[0-9]+) <-> (?<message>[0-9A-Za-z]+$)");

            if (!regexBroadcast.Success && ! regexMessage.Success)
            {
                continue;
            }

            if (regexBroadcast.Success)
            {
                InsertBroadcast(data, regexBroadcast);
            }

            if (regexMessage.Success)
            {
                InsertMessage(data, regexMessage);
            }
        }

        PrintResult(data);
    }

    private static void InsertBroadcast(Dictionary<string, List<Query>> data, Match regexBroadcast)
    {
        string message = regexBroadcast.Groups["message"].Value;
        StringBuilder frequency = new StringBuilder();
        foreach (var l in regexBroadcast.Groups["frequency"].Value)
        {
            if (char.IsLower(l))
            {
                frequency.Append(char.ToUpper(l));
            }
            else if (char.IsUpper(l))
            {
                frequency.Append(char.ToLower(l));
            }
            else
            {
                frequency.Append(l);
            }
        }

        data["broadcast"].Add(new Query()
        {
            Frequency = frequency.ToString(),
            Message = message
        });
    }

    private static void InsertMessage(Dictionary<string, List<Query>> data, Match regexMessage)
    {
        string message = regexMessage.Groups["message"].Value;
        string recipient = new String(regexMessage.Groups["recipient"].Value
            .Reverse()
            .ToArray());

        data["message"].Add(new Query()
        {
            Recipient = recipient,
            Message = message
        });
    }

    private static void PrintResult(Dictionary<string, List<Query>> data)
    {
        foreach (var kvp in data)
        {
            if (kvp.Key.Equals("broadcast"))
            {
                Console.WriteLine("Broadcasts:");

                if (kvp.Value.Count == 0)
                {
                    Console.WriteLine("None");
                    continue;
                }

                foreach (var q in kvp.Value)
                {
                    Console.WriteLine($"{q.Frequency} -> {q.Message}");
                }
            }

            if (kvp.Key.Equals("message"))
            {
                Console.WriteLine("Messages:");

                if (kvp.Value.Count == 0)
                {
                    Console.WriteLine("None");
                    continue;
                }

                foreach (var q in kvp.Value)
                {
                    Console.WriteLine($"{q.Recipient} -> {q.Message}");
                }
            }
        }
    }
}