using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class SoftUniKaraoke
{
    static void Main()
    {
        var input = new Dictionary<string, List<string>>();
        string[] namePlayers = Regex.Split(Console.ReadLine(), @"\s*,\s*");
        string[] nameSongs = Regex.Split(Console.ReadLine(), @"\s*,\s*");

        foreach (var item in namePlayers)
        {
            input[item] = new List<string>();
        }

        AddedParticipant(input, namePlayers, nameSongs);

        PrintResult(input);
    }

    static void AddedParticipant(Dictionary<string, List<string>> input, string[] namePlayers, string[] nameSongs)
    {
        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("dawn"))
            {
                break;
            }

            string[] tokens = Regex.Split(command, @"\s*,\s*");

            string participant = tokens[0];
            string song = tokens[1];
            string award = tokens[2];

            bool hasPlayersAndSongs =
                namePlayers.Contains(participant) && nameSongs.Contains(song);
            if (hasPlayersAndSongs)
            {
                input[participant].Add(award);
            }
        }
    }

    static void PrintResult(Dictionary<string, List<string>> input)
    {
        var result = input
            .Select(item => new
            {
                playerName = item.Key,
                awards = item.Value.Distinct().OrderBy(x => x),
                awardsCount = item.Value.Distinct().Count()
            })
            .Where(x => x.awardsCount > 0)
            .OrderByDescending(x => x.awardsCount)
            .ThenBy(x => x.playerName)
            .ToArray();

        foreach (var p in result)
        {
            Console.WriteLine($"{p.playerName}: {p.awardsCount} awards");

            foreach (var aw in p.awards.OrderBy(x => x))
            {
                Console.WriteLine($"--{aw}");
            }
        }

        if (result.Length.Equals(0))
        {
            Console.WriteLine("No awards");
        }
    }
}