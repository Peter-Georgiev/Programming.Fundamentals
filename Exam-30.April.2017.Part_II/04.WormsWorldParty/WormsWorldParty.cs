using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class Worms
{
    public string WormName { get; set; }
    public long WormScore { get; set; }
}

class WormsWorldParty
{
    static void Main()
    {
        Dictionary<string, List<Worms>> result = new Dictionary<string, List<Worms>>();

        InsertTeamWormsScore(result);

        PruntResult(result);
    }

    static void PruntResult(Dictionary<string, List<Worms>> result)
    {
        int count = 1;
        foreach (var kvp in result
            .OrderByDescending(x => x.Value.Sum(c => c.WormScore))
            .ThenBy(x => x.Value.Count())
            .ThenBy(x => x.Value.Max(c => c.WormScore)))
        {
            long sum = kvp.Value.Sum(x => x.WormScore);
            Console.WriteLine($"{count++}. Team: {kvp.Key} - {sum}");

            foreach (var w in kvp.Value.OrderByDescending(x => x.WormScore))
            {
                Console.WriteLine($"###{w.WormName} : {w.WormScore}");
            }
        }
    }

    static void InsertTeamWormsScore(Dictionary<string, List<Worms>> result)
    {
        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("quit"))
            {
                break;
            }

            Match regex = Regex.Match(readLine, @"(?<worm>.+) -> (?<team>.+) -> (?<score>\d+)");

            string worm = regex.Groups["worm"].Value;

            bool hasWorms = true;
            foreach (var kvp in result)
            {
                foreach (var w in kvp.Value)
                {
                    if (w.WormName == worm)
                    {
                        hasWorms = false;
                    }
                }
            }

            if (hasWorms)
            {
                string team = regex.Groups["team"].Value;
                long score = long.Parse(regex.Groups["score"].Value);

                if (!result.ContainsKey(team))
                {
                    result.Add(team, new List<Worms>());
                }

                Worms newWorm = new Worms()
                {
                    WormName = worm,
                    WormScore = score
                };

                result[team].Add(newWorm);
            }
        }
    }
}