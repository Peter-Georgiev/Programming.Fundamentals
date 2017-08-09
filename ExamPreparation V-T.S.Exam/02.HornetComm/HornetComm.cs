using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

class Query
{
    public string Recipient { get; set; }

    public string Frequency { get; set; }

    public string Message { get; set; }
}

class HornetComm
{
    static void Main()
    {
        SortedDictionary<string, List<Query>> result =
            new SortedDictionary<string, List<Query>>
            {
                { "Messages", new List<Query>() },
                { "Broadcasts", new List<Query>() }
            };

        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("Hornet is Green"))
            {
                break;
            }

            GetMessages(result, readLine);

            GetBroadcasts(result, readLine);
        }

        PrintResult(result);
    }

    static void GetMessages(SortedDictionary<string, List<Query>> result, string readLine)
    {
        Match regex = Regex.Match(readLine,
            @"(?<firstQuery>^\d+) <-> (?<message>[A-Za-z0-9]+$)");
        if (regex.Success)
        {
            Query newMessage = new Query()
            {
                Recipient = GetReversLetter(regex),
                Message = regex.Groups["message"].Value
            };

            result["Messages"].Add(newMessage);
        }
    }

    static void GetBroadcasts(SortedDictionary<string, List<Query>> result, string readLine)
    {
        Match regex = Regex.Match(readLine,
           @"(?<firstQuery>^[^0-9]+) <-> (?<secondQuery>[A-Za-z0-9]+$)");
        if (regex.Success)
        {
            Query newBroadcast = new Query()
            {
                Frequency = GetUpperAndLowerLetters(regex),
                Message =
                regex.Groups["firstQuery"].Value
            };
                        
            result["Broadcasts"].Add(newBroadcast);
        }
    }

    static string GetReversLetter(Match regex)
    {
        string firstQuery = String.Concat(
            regex.Groups["firstQuery"].Value
            .ToCharArray()
            .Reverse());
        return firstQuery;
    }

    static string GetUpperAndLowerLetters(Match regex)
    {
        string frequency = regex.Groups["secondQuery"].Value;
        StringBuilder newFrequency = new StringBuilder();

        foreach (var str in frequency)
        {
            if (Char.IsLower(str))
            {
                newFrequency.Append(Char.ToUpper(str));
            }
            else if (Char.IsUpper(str))
            {
                newFrequency.Append(Char.ToLower(str));
            }
            else
	        {
                newFrequency.Append(str);
            }
        }

        return newFrequency.ToString();
    }

    static void PrintResult(SortedDictionary<string, List<Query>> result)
    {
        foreach (var kvp in result)
        {
            Console.WriteLine(kvp.Key + ":");
            bool isNone = true;

            foreach (var q in kvp.Value)
            {
                if (kvp.Key.Equals("Broadcasts"))
                {
                    Console.WriteLine($"{q.Frequency} -> {q.Message}");
                }
                else if (kvp.Key.Equals("Messages"))
                {
                    Console.WriteLine($"{q.Recipient} -> {q.Message}");
                }
                isNone = false;
            }

            if (isNone)
            {
                Console.WriteLine("None");
            }
        }
    }
}