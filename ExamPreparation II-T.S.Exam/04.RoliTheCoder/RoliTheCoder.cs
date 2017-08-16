using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Events
{
    public string Name { get; set; }

    public HashSet<string> Participant { get; set; }

    public Events(string name)
    {
        this.Name = name;
        this.Participant = new HashSet<string>();
    }

}

class RoliTheCoder
{
    static void Main()
    {
        Dictionary<int, Events> data =
            new Dictionary<int, Events>();

        InsertEvent(data);

        PrintResult(data);
    }

    private static void PrintResult(Dictionary<int, Events> data)
    {
        foreach (var e in data.Values.OrderByDescending(p => p.Participant.Count).ThenBy(n => n.Name))
        {
            Console.WriteLine($"{e.Name} - {e.Participant.Count}");

            foreach (var p in e.Participant.OrderBy(p => p))
            {
                Console.WriteLine("@" + p);
            }
        }
    }

    private static void InsertEvent(Dictionary<int, Events> data)
    {
        string readLine;
        while ((readLine = Console.ReadLine()) != "Time for Code")
        {
            Match regex = Regex.Match(readLine,
                @"(?<id>\d+) #(?<name>\w+).*");

            if (!regex.Success)
            {
                continue;
            }

            int id = int.Parse(regex.Groups["id"].Value);
            string name = regex.Groups["name"].Value;

            string[] tokens = readLine
                .Split(new[] { ' ', '@' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .ToArray();

            if (!data.ContainsKey(id))
            {
                data.Add(id, new Events(name));
            }

            if (data[id].Name == name)
            {
                for (int i = 2; i < tokens.Length; i++)
                {
                    data[id].Participant.Add(tokens[i]);
                }
            }
        }
    }
}