using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Team
{
    public string Player { get; set; }
    public int Point { get; set; }

    public Team(string player, int point)
    {
        this.Player = player;
        this.Point = point;
    }
}

class PointsCounter
{
    static void Main()
    {
        var teams = new Dictionary<string, List<Team>>();

        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.ToLower().Equals("result"))
            {
                break;
            }

            string[] tokens = readLine
                .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string team = String.Empty;
            string player = String.Empty;
            int points = int.Parse(tokens[2]);

            GetTeamAndPlayer(tokens, ref team, ref player);

            if (team.Equals(String.Empty) || player.Equals(String.Empty))
            {
                continue;
            }

            InsertTiems(teams, team, player, points);
        }

        PrintResult(teams);
    }

    static void InsertTiems(Dictionary<string, List<Team>> teams, string team, string player, int points)
    {
        if (!teams.ContainsKey(team))
        {
            teams.Add(team, new List<Team>());
        }

        bool hasTeamPlayerPoints = false;

        foreach (var kvp in teams)
        {
            if (kvp.Key.Equals(team))
            {
                foreach (var p in kvp.Value)
                {
                    if (p.Player.Equals(player))
                    {
                        p.Point = points;
                        hasTeamPlayerPoints = true;
                    }
                }
            }
        }

        if (!hasTeamPlayerPoints)
        {
            Team newTeam = new Team(player, points);

            teams[team].Add(newTeam);
        }
    }

    static void GetTeamAndPlayer(string[] tokens, ref string team, ref string player)
    {
        for (int i = 0; i < tokens.Length - 1; i++)
        {
            char[] ch = new char[] { '@', '%', '$', '*', '&' };
            char[] tempCh = tokens[i]
                .ToCharArray()
                .Where(x => !ch.Contains(x))
                .ToArray();

            char[] isUpper = tempCh
                .Where(x => Char.IsUpper(x))
                .ToArray();
            char[] isLower = tempCh
                .Where(x => Char.IsLower(x))
                .ToArray();

            if (tempCh.Length == isUpper.Length && tempCh.Length > 1)
            {
                team = string.Join("", tempCh);
            }
            else if (tempCh.Length == isLower.Length + 1)
            {
                player = string.Join("", tempCh);
            }
        }
    }

    static void PrintResult(Dictionary<string, List<Team>> teams)
    {
        var sortTeams = teams
                    .OrderByDescending(t => t.Value.Sum(p => p.Point))
                    .ToList();

        foreach (var kvp in sortTeams)
        {
            Console.WriteLine(kvp.Key + " => " + kvp.Value.Sum(x => x.Point));

            var nameOfThePlayer = kvp.Value
                .OrderByDescending(x => x.Point)
                .ToArray();
            Console.WriteLine(
                $"Most points scored by {nameOfThePlayer[0].Player}");
        }
    }
}