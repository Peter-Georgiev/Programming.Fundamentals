using System;
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
        string pattern = @"(?<tail>[>]*)(?<startTail><)(?<body>[(]+)(?<status>['-Xx])(?<head>>)";

        string readLine = Console.ReadLine();

        MatchCollection regex = Regex.Matches(readLine, pattern);

        foreach (Match r in regex)
        {
            Fish newFish = new Fish()
            {
                Picture = GetPictureFish(r),
                Tail = r.Groups["tail"].Length * 2,
                StatusTail = GetStatusTailType(r),
                Body = r.Groups["body"].Length * 2,
                StatusBody = GetStatusBodyType(r),
                Status = GetStatusFish(r)
            };

            fished.Add(newFish);
        }

        PrintFish(fished);
    }

    static string GetStatusBodyType(Match r)
    {
        string type = String.Empty;

        if (r.Groups["body"].Length > 10)
        {
            type = "Long";
        }
        else if (r.Groups["body"].Length > 5)
        {
            type = "Medium";
        }
        else
        {
            type = "Short";
        }

        return type;
    }

    static string GetStatusTailType(Match r)
    {
        string type = String.Empty;

        if (r.Groups["tail"].Length > 5)
        {
            type = "Long";
        }
        else if (r.Groups["tail"].Length > 1)
        {
            type = "Medium";
        }
        else if (r.Groups["tail"].Length.Equals(1))
        {
            type = "Short";
        }
        else
        {
            type = "None";
        }

        return type;
    }
    
    static string GetPictureFish(Match r)
    {
        string pictureFish = String.Empty;

        if (!r.Groups["tail"].Length.Equals(0))
        {
            pictureFish += r.Groups["tail"].Value;
        }

        pictureFish += r.Groups["startTail"].Value;
        pictureFish += r.Groups["body"].Value;
        pictureFish += r.Groups["status"].Value;
        pictureFish += r.Groups["head"].Value;

        return pictureFish;      
    }

    static string GetStatusFish(Match r)
    {
        string status = String.Empty;
        if (r.Groups["status"].Value.Equals("'"))
        {
            status = "Awake";
        }
        else if (r.Groups["status"].Value.Equals("-"))
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
            Console.WriteLine("No fish found.");
        }
        else
        {
            int count = 1;
            foreach (var fish in fished)
            {
                Console.WriteLine($"Fish {count++}: {fish.Picture}");

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
            }
        }
    }
}