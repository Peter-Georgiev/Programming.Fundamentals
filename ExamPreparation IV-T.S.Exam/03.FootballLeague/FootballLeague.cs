using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Team
{
    public string TeamName { get; set; }
    public long Score { get; set; }
    public long Points { get; set; }
}

class FootballLeague
{
    static void Main()
    {
        List<Team> teams = new List<Team>();

        string key = Console.ReadLine();

        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("final"))
            {
                break;
            }

            string teamA, teamB;
            long scoreTeamA, scoreTeamB;

            ReadMatchInput(key, command, out teamA, out teamB, out scoreTeamA, out scoreTeamB);

            ReadStandings(teams, teamA, teamB, scoreTeamA, scoreTeamB);
        }

        PrintResult(teams);
    }
    
    static void ReadMatchInput(string key, string command, out string teamA, out string teamB, out long scoreTeamA, out long scoreTeamB)
    {
        string pattern = Regex.Escape(key);

        Regex regex =
            new Regex($@"(?<teamA>({pattern}).*?(\1)).+?(?<teamB>(\1).*?(\1)).+?(?<score>\d+:\d+)");
        Match match = regex.Match(command);

        teamA = String.Join("",
            match.Groups["teamA"].Value
            .ToUpper()
            .Remove(match.Groups["teamA"].Value.Length - key.Length, key.Length)
            .Remove(0, key.Length)
            .ToCharArray()
            .Reverse());
        teamB = String.Join("",
            match.Groups["teamB"].Value
            .ToUpper()
            .Remove(match.Groups["teamB"].Value.Length - key.Length, key.Length)
            .Remove(0, key.Length)
            .ToCharArray()
            .Reverse());
        long[] scoreTeamsAandB = match.Groups["score"].Value
            .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();
        scoreTeamA = scoreTeamsAandB[0];
        scoreTeamB = scoreTeamsAandB[1];
    }

    static void ReadStandings(List<Team> teams, string teamA, string teamB, long scoreTeamA, long scoreTeamB)
    {
        Team newTeamA = new Team();
        Team newTeamB = new Team();

        newTeamA.TeamName = teamA;
        newTeamA.Score = scoreTeamA;
        newTeamB.TeamName = teamB;
        newTeamB.Score = scoreTeamB;

        if (scoreTeamA == scoreTeamB)
        {
            newTeamA.Points = 1;
            newTeamB.Points = 1;
        }
        else if (scoreTeamA > scoreTeamB)
        {
            newTeamA.Points = 3;
        }
        else if (scoreTeamB > scoreTeamA)
        {
            newTeamB.Points = 3;
        }

        teams.Add(newTeamA);
        teams.Add(newTeamB);
    }

    static void PrintResult(List<Team> teams)
    {

        Console.WriteLine("League standings:");
        int count = 1;
        foreach (var p in SortedPoints(teams))
        {
            Console.WriteLine($"{count++}. {p.Key} {p.Value}");
        }

        

        Console.WriteLine("Top 3 scored goals:");
        foreach (var s in SortedScore(teams))
        {
            Console.WriteLine($"- {s.Key} -> {s.Value}");
        }
    }

    static Dictionary<string, long> SortedScore(List<Team> teams)
    {
        ////////////// Print -> Top 3 scored goals //////////////
        Dictionary<string, long> sorted = new Dictionary<string, long>();

        foreach (var t in teams)
        {
            if (!sorted.ContainsKey(t.TeamName))
            {
                sorted.Add(t.TeamName, 0);
            }

            sorted[t.TeamName] += t.Score;
        }

        teams.Clear();

        sorted = sorted
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .Take(3)
            .ToDictionary(x => x.Key, x => x.Value);
        return sorted;
    }

    static Dictionary<string, long> SortedPoints(List<Team> teams)
    {
        ////////////// Print -> League standings //////////////
        Dictionary<string, long> sorted = new Dictionary<string, long>();

        foreach (var t in teams)
        {
            if (!sorted.ContainsKey(t.TeamName))
            {
                sorted.Add(t.TeamName, 0);
            }

            sorted[t.TeamName] += t.Points;
        }

        sorted = sorted
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);
        return sorted;
    }
}