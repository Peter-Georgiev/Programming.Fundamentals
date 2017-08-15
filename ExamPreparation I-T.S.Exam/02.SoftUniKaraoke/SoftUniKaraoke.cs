using System;
using System.Linq;
using System.Collections.Generic;

class SoftUniKaraoke
{
    static void Main()
    {
        Dictionary<string, HashSet<string>> input =
            new Dictionary<string, HashSet<string>>();

        string[] participants = InsertParticipant();
        string[] songs = InsertSongs();

        string readLine = String.Empty;
        while ((readLine = Console.ReadLine()) != "dawn")
        {
            InsertParticipantSongAward(input, participants, songs, readLine);
        }

        PrintResult(input);
    }

    private static void PrintResult(Dictionary<string, HashSet<string>> input)
    {
        if (input.Count.Equals(0))
        {
            Console.WriteLine("No awards");
            return;
        }

        foreach (var kvp in input.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} awards");

            foreach (var a in kvp.Value.OrderBy(x => x))
            {
                Console.WriteLine("--" + a);
            }
        }
    }

    private static void InsertParticipantSongAward(Dictionary<string, HashSet<string>> input, string[] participants, string[] songs, string readLine)
    {
        string[] tokens = readLine
            .Split(new string[] { ", " },
            StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        string participant = tokens[0].Trim();
        string song = tokens[1].Trim();
        string award = tokens[2].Trim();

        if (!participants.Contains(participant) || !songs.Contains(song))
        {
            return;
        }

        if (!input.ContainsKey(participant))
        {
            input.Add(participant, new HashSet<string>());
        }

        input[participant].Add(award);
    }

    private static string[] InsertSongs()
    {
        string[] tokensSongs = Console.ReadLine()
            .Split(new string[] { ", " },
            StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string[] songs = new string[tokensSongs.Length];

        for (int i = 0; i < songs.Length; i++)
        {
            songs[i] = tokensSongs[i].Trim();
        }
        return songs;
    }

    private static string[] InsertParticipant()
    {
        string[] tokensParticipants = Console.ReadLine()
                    .Split(new string[] { ", " },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

        string[] participants = new string[tokensParticipants.Length];

        for (int i = 0; i < participants.Length; i++)
        {
            participants[i] = tokensParticipants[i].Trim();
        }
        return participants;
    }
}