using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Events
{
    public string Name { get; set; }
    public List<string> Participant { get; set; }

    public Events(string name)
    {
        this.Name = name;
        this.Participant = new List<string>();
    }
}

class RoliTheCoder
{
    static void Main()
    {
        var events = new Dictionary<int, Events>();

        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("Time for Code"))
            {
                break;
            }

            Match regex = Regex.Match(command,
                @"(?<id>\d+) #(?<event>\w+)\s*(?<participants>(?:@[a-zA-Z0-9'-]+\s*)*)");
            if (!regex.Success)
            {
                continue;
            }

            int ID = int.Parse(regex.Groups["id"].Value.Trim());
            string eventName = regex.Groups["event"].Value.Trim();
            string participantsStr = regex.Groups["participants"].Value;
            string[] participants = new string[0];

            if (participantsStr.Length > 0)
            {
                participants = participantsStr
                    .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            if (!events.ContainsKey(ID))
            {
                Events newEvent = new Events(eventName);
                newEvent.Participant.AddRange(participants);

                events[ID] = newEvent;
            }

            if (events[ID].Name == eventName)
            {
                events[ID].Participant.AddRange(participants);
            }

            foreach (var e in events)
            {
                e.Value.Participant = e.Value.Participant
                    .Distinct()
                    .OrderBy(a => a)
                    .ToList();
            }
        }

        PrintResult(events);
    }

    static void PrintResult(Dictionary<int, Events> events)
    {
        var result = events
                    .OrderByDescending(x => x.Value.Participant.Count)
                    .ThenBy(x => x.Value.Name)
                    .Select(a => a.Value)
                    .ToList();

        foreach (var e in result)
        {
            Console.WriteLine($"{e.Name} - {e.Participant.Count}");
            
            foreach (var p in e.Participant)
            {
                Console.WriteLine(p);
            }
        }
    }
}