using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class Teams
{
    public long Points { get; set; }

    public long Globals { get; set; }

    public Teams(long points, long globals)
    {
        this.Points = points;
        this.Globals = globals;
    }
}

class FootballLeague
{
    static void Main()
    {
        Dictionary<string, Teams> teams = new Dictionary<string, Teams>();

        Regex key = new Regex(Regex.Escape(Console.ReadLine()));

        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("final"))
            {
                break;
            }

            Match regex = Regex.Match(readLine,
                $@".*?({key})(?<teamA>.*?)({key}).+?({key})(?<teamB>.*?)({key}).*?(?<scoreA>\d+):(?<scoreB>\d+)");

            InsertTeams(teams, regex);
        }
        
        PrintResult(teams);
    }

    static void PrintResult(Dictionary<string, Teams> teams)
    {
        int place = 1;
        Console.WriteLine("League standings:");

        foreach (var kvp in teams.OrderByDescending(x => x.Value.Points).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{place++}. {kvp.Key} {kvp.Value.Points}");
        }

        Console.WriteLine("Top 3 scored goals:");

        foreach (var kvp in teams.OrderByDescending(x => x.Value.Globals).ThenBy(x => x.Key).Take(3))
        {
            Console.WriteLine($"- {kvp.Key} -> {kvp.Value.Globals}");
        }
    }

    static void InsertTeams(Dictionary<string, Teams> teams, Match regex)
    {
        string teamA = SplitTeam(regex, "teamA");
        string teamB = SplitTeam(regex, "teamB");
        int scoreA = int.Parse(regex.Groups["scoreA"].Value);
        int scoreB = int.Parse(regex.Groups["scoreB"].Value);
        
        InsertTeamAandB(teams, teamA, teamB);

        if (scoreA == scoreB)
        {
            GetTeamDraw(teams, teamA, teamB, scoreA, scoreB);
        }
        else if (scoreA > scoreB)
        {
            GetTeamA3PointsAndTeamBlos(teams, teamA, teamB, scoreA, scoreB);
        }
        else if (scoreA < scoreB)
        {
            GetTeamB3PointsAndTeamAlos(teams, teamA, teamB, scoreA, scoreB);
        }
    }

    static void GetTeamB3PointsAndTeamAlos(Dictionary<string, Teams> teams, string teamA, string teamB, int scoreA, int scoreB)
    {
        foreach (var t in teams)
        {
            if (t.Key == teamA)
            {
                t.Value.Globals += scoreA;
            }
            else if (t.Key == teamB)
            {
                t.Value.Points += 3;
                t.Value.Globals += scoreB;
            }
        }
    }

    static void GetTeamA3PointsAndTeamBlos(Dictionary<string, Teams> teams, string teamA, string teamB, int scoreA, int scoreB)
    {
        foreach (var t in teams)
        {
            if (t.Key == teamA)
            {
                t.Value.Points += 3;
                t.Value.Globals += scoreA;
            }
            else if (t.Key == teamB)
            {
                t.Value.Globals += scoreB;
            }
        }
    }

    static void GetTeamDraw(Dictionary<string, Teams> teams, string teamA, string teamB, int scoreA, int scoreB)
    {
        foreach (var t in teams)
        {
            if (t.Key == teamA)
            {
                t.Value.Points++;
                t.Value.Globals += scoreA;
            }
            else if (t.Key == teamB)
            {
                t.Value.Points++;
                t.Value.Globals += scoreB;
            }
        }
    }

    static string SplitTeam(Match regex, string team)
    {
        return String.Concat(regex.Groups[$"{team}"].Value.Trim()
                        .ToUpper()
                        .ToCharArray()
                        .Reverse());
    }

    static void InsertTeamAandB(Dictionary<string, Teams> teams, string teamA, string teamB)
    {
        if (!teams.ContainsKey(teamA))
        {
            teams.Add(teamA, new Teams(0, 0));
        }

        if (!teams.ContainsKey(teamB))
        {
            teams.Add(teamB, new Teams(0, 0));
        }
    }
}