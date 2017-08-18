using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Team
{
    public long Globals { get; set; }

    public long Points { get; set; }

    public Team(long points, long globals)
    {
        this.Globals = globals;
        this.Points = points;
    }
}

class FootballLeague
{
    static void Main()
    {
        Dictionary<string, Team> data =
            new Dictionary<string, Team>();

        string readLine = Console.ReadLine();
        string key = Regex.Escape(readLine);

        while ((readLine = Console.ReadLine()) != "final")
        {
            InsertTeam(data, readLine, key);
        }

        PrintResult(data);
    }

    private static void InsertTeam(Dictionary<string, Team> data, string readLine, string key)
    {
        Match regex = Regex.Match(readLine,
                        $@"{key}(?<teamA>.*?){key}.*{key}(?<teamB>.*){key}.*?(?<scoreA>\d+):(?<scoreB>\d+)");

        string teamA = GetTeamName(regex.Groups["teamA"].Value);
        string teamB = GetTeamName(regex.Groups["teamB"].Value);
        long scoreA = long.Parse(regex.Groups["scoreA"].Value);
        long scoreB = long.Parse(regex.Groups["scoreB"].Value);
        long pointsA = 0;
        long pointsB = 0;

        if (scoreA > scoreB)
        {
            pointsA += 3;
        }
        else if (scoreB > scoreA)
        {
            pointsB += 3;
        }
        else if (scoreA == scoreB)
        {
            pointsA++;
            pointsB++;
        }

        if (!data.ContainsKey(teamA))
        {
            data.Add(teamA, new Team(0, 0));
        }

        if (!data.ContainsKey(teamB))
        {
            data.Add(teamB, new Team(0, 0));
        }

        data[teamA].Globals += scoreA;
        data[teamA].Points += pointsA;
        data[teamB].Globals += scoreB;
        data[teamB].Points += pointsB;
    }

    private static void PrintResult(Dictionary<string, Team> data)
    {
        int count = 1;
        Console.WriteLine("League standings:");
        foreach (var kvp in data.OrderByDescending(x => x.Value.Points).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{count++}. {kvp.Key} {kvp.Value.Points}");
        }

        Console.WriteLine("Top 3 scored goals:");
        foreach (var kvp in data.OrderByDescending(x => x.Value.Globals).ThenBy(x => x.Key).Take(3))
        {
            Console.WriteLine($"- {kvp.Key} -> {kvp.Value.Globals}");
        }
    }

    private static string GetTeamName(string s)
    {
        return String.Concat(s
                        .ToUpper()
                        .Reverse()
                        .ToArray());
    }
}