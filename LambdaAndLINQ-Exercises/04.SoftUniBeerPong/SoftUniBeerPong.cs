using System;
using System.Collections.Generic;
using System.Linq;

class SoftUniBeerPong
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> gamesBase =
            new Dictionary<string, Dictionary<string, int>>();

        gamesBase = InsertTeamUser();

        gamesBase = IfOfThree(gamesBase);

        gamesBase = EqualThree(gamesBase);

        var sumDic = TeamPoints(gamesBase);

        PrinTeamUser(gamesBase, sumDic);
    }
    
    private static void PrinTeamUser(Dictionary<string, Dictionary<string, int>> gamesBase, Dictionary<string, int> sumDic)
    {
        byte count = 1;

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

    private static Dictionary<string, int> TeamPoints(
        Dictionary<string, Dictionary<string, int>> gamesBase)
    {
        var dictionary = 
            new Dictionary<string, int>();

        foreach (var kvpBase in gamesBase)
        {
            string team = kvpBase.Key;
            int sum = kvpBase.Value.Values.Sum();

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
      
    private static Dictionary<string, Dictionary<string, int>> InsertTeamUser()
    {
        var dictionary =
            new Dictionary<string, Dictionary<string, int>>();

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

                var t = dictionary.Values
                 .SelectMany(list => list)
                 .Distinct()
                 .Count();

            }
        }
        return dictionary;
    }

    private static Dictionary<string, Dictionary<string, int>> IfOfThree(Dictionary<string, Dictionary<string, int>> gamesBase)
    {
        var dictionary = gamesBase
            .Where(x => x.Value.Keys.Count >= 3)
            .ToDictionary(x => x.Key, x => x.Value);
        return dictionary;
    }

    private static Dictionary<string, Dictionary<string, int>> EqualThree(Dictionary<string, Dictionary<string, int>> gamesBase)
    {
        var dictionary = new Dictionary<string, Dictionary<string, int>>();

        foreach (var kvp in gamesBase)
        {
            string team = kvp.Key;
            Dictionary<string, int> playerdic = kvp.Value;

            dictionary.Add(team, new Dictionary<string, int>());

            byte count = 0;

            foreach (var kvpplayer in playerdic)
            {
                string player = kvpplayer.Key;
                int pointmode = kvpplayer.Value;
                if (count < 3)
                {
                    dictionary[team][player] = pointmode;
                }
                else
                {
                    break;
                }
                count++;
            }
        }
        return dictionary;
    }
}