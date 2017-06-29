using System;
using System.Collections.Generic;
using System.Linq;

class SoftUniBeerPong
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> gamesBase =
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

                if (!gamesBase.ContainsKey(team))
                {
                    gamesBase.Add(team, new Dictionary<string, int>());
                }
                
                gamesBase[team][player] = pointsMade;
            }            
        }
                
        var tempGamesBase = gamesBase
            .Where(x => x.Value.Keys.Count >= 3)
            .ToDictionary(x => x.Key, x => x.Value);
        gamesBase.Clear();

        foreach (var kvp in tempGamesBase)
        {
            string team = kvp.Key;
            Dictionary<string, int> playerDic = kvp.Value;

            gamesBase.Add(team, new Dictionary<string, int>());

            byte count = 0;

            foreach (var kvpPlayer in playerDic)
            {
                string player = kvpPlayer.Key;
                int pointMode = kvpPlayer.Value;
                if (count < 3)
                {
                    gamesBase[team][player] = pointMode;
                }
                else
                {
                    break;
                }
                count++;
            }
        }

        tempGamesBase.Clear();

        var result = gamesBase
            .ToDictionary(x => x.Key, x => x.Value).Values;

        Console.WriteLine();

    }
}