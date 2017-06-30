using System;
using System.Collections.Generic;
using System.Linq;

class SoftUniBeerPong
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> gamesBase =
            new Dictionary<string, Dictionary<string, int>>();

        gamesBase = InsertTeamAndUpToThreeUsers();

        gamesBase = RemoveLessThanThreeUsers(gamesBase);

        var sumDic = SumTeamsPoints(gamesBase);

        PrinTeamUser(gamesBase, sumDic);
    }

    private static Dictionary<string, Dictionary<string, int>> InsertTeamAndUpToThreeUsers()
    {
        var dictionary = new Dictionary<string, Dictionary<string, int>>();

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("stop the game"))
            {
                break;
            }
            else
            {
                string[] input = readLine
                    .Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string player = input[0];
                string team = input[1];
                int pointsMade = int.Parse(input[2]);
                
                if (!dictionary.ContainsKey(team))
                {
                    dictionary.Add(team, new Dictionary<string, int>());
                    dictionary[team][player] = pointsMade;
                }

                foreach (var kvpTeam in dictionary)
                {
                    string teamKey = kvpTeam.Key;
                    var players = kvpTeam.Value;

                    if (teamKey == team)
                    {
                        if (players.Count() < 3)
                        {
                            dictionary[team][player] = pointsMade;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        return dictionary;
    }

    private static Dictionary<string, Dictionary<string, int>> RemoveLessThanThreeUsers(Dictionary<string, Dictionary<string, int>> gamesBase)
    {
        var dictionary = gamesBase
            .Where(x => x.Value.Keys.Count.Equals(3))
            .ToDictionary(x => x.Key, x => x.Value);

        return dictionary;
    }
   
    private static Dictionary<string, long> SumTeamsPoints(
        Dictionary<string, Dictionary<string, int>> gamesBase)
    {
        var dictionary = new Dictionary<string, long>();

        foreach (var kvpBase in gamesBase)
        {
            string team = kvpBase.Key;
            long sum = kvpBase.Value.Values.Sum();

            foreach (var kvpPlayer in kvpBase.Value)                
            {
                if (!dictionary.ContainsKey(team))
                {
                    dictionary.Add(team, sum);
                }
            }            
        }

        return dictionary
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);
    }

    private static void PrinTeamUser(Dictionary<string, Dictionary<string, int>> gamesBase, Dictionary<string, long> sumDic)
    {
        int count = 1;

        foreach (var kvpSum in sumDic)
        {
            foreach (var kvpBase in gamesBase)
            {
                if (kvpSum.Key == kvpBase.Key)
                {
                    Console.WriteLine(
                        $"{count}. {kvpBase.Key}; Players:");

                    var players = kvpBase.Value
                         .OrderByDescending(x => x.Value)
                         .ToDictionary(x => x.Key, x => x.Value);

                    foreach (var kvpPlayer in players)
                    {
                        Console.WriteLine(
                            $"###{kvpPlayer.Key}: {kvpPlayer.Value}");
                    }
                }
            }

            count++;
        }
    }
}