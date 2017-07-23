using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Fish
{
    public string Picture { get; set; }

    public int Tail { get; set; }

    public int Body { get; set; }

    public string Status { get; set; }

    public string StatusTail { get; set; }

    public string StatusBody { get; set; }
}

class FishStatistics
{
    static void Main()
    {
        List<Fish> fished = new List<Fish>();
        string pattern = @"((?<tail>[>]+)?(?<startTail>[<]))(?<body>[(]+)(?<status>['-Xx][>])";

        string input = Console.ReadLine();

        MatchCollection regexMatches = Regex.Matches(input, pattern);

        foreach (Match regex in regexMatches)
        {
            Fish newFish = new Fish()
            {
                Picture = GetPictureFish(regex),
                Tail = regex.Groups["tail"].Length * 2,
                StatusTail = GetStatusTypeTail(regex),
                Body = regex.Groups["body"].Length * 2,
                StatusBody = GetStatusTypeBody(regex),
                Status = GetStatusFish(regex)
            };

            fished.Add(newFish);
        }

        PrintFish(fished);
    }

    static string GetStatusTypeBody(Match regex)
    {
        string type = String.Empty;

        if (regex.Groups["body"].Length > 10)
        {
            type = "Long";
        }
        else if (regex.Groups["body"].Length > 5)
        {
            type = "Medium";
        }
        else
        {
            type = "Short";
        }

        return type;
    }

    static string GetStatusTypeTail(Match regex)
    {
        string type = String.Empty;

        if (regex.Groups["tail"].Length > 5)
        {
            type = "Long";
        }
        else if (regex.Groups["tail"].Length > 1)
        {
            type = "Medium";
        }
        else if (regex.Groups["tail"].Length.Equals(1))
        {
            type = "Short";
        }
        else
        {
            type = "None";
        }

        return type;
    }
    
    static string GetPictureFish(Match regex)
    {
        string pictureFish = String.Empty;

        if (!regex.Groups["tail"].Length.Equals(0))
        {
            pictureFish += regex.Groups["tail"].Value;
        }

        pictureFish += regex.Groups["startTail"].Value;
        pictureFish += regex.Groups["body"].Value;
        pictureFish += regex.Groups["status"].Value;

        return pictureFish;      
    }

    static string GetStatusFish(Match regex)
    {
        string status = String.Empty;
        if (regex.Groups["status"].Value.Equals("'>"))
        {
            status = "Awake";
        }
        else if (regex.Groups["status"].Value.Equals("->"))
        {
            status = "Asleep";
        }
        else
        {
            status = "Dead";
        }

        return status;
    }

    static void PrintFish(List<Fish> fished)
    {
        if (fished.Count.Equals(0))
        {
            Console.WriteLine("No fish found");
        }
        else
        {
            int count = 1;
            foreach (var fish in fished)
            {
                Console.WriteLine($"Fish {count}: {fish.Picture}");

                if (fish.StatusTail.Equals("None"))
                {
                    Console.WriteLine($"\tTail type: {fish.StatusTail}");
                }
                else
                {
                    Console.WriteLine($"\tTail type: {fish.StatusTail} ({fish.Tail} cm)");
                }

                if (fish.StatusBody.Equals("None"))
                {
                    Console.WriteLine($"\tBody type: {fish.StatusBody}");
                }
                else
                {
                    Console.WriteLine($"\tBody type: {fish.StatusBody} ({fish.Body} cm)");
                }

                Console.WriteLine($"\tStatus: {fish.Status}");

                count++;
            }
        }
    }
}