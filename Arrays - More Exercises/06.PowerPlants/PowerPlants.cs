using System;
using System.Linq;

class PowerPlants
{
    static void Main()
    {
        int[] forest = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int daysEnd = 0;
        int seasons = 0;

        while (!forest.Max().Equals(0))
        {
            for (int i = 0; i < forest.Length; i++) //Days
            {
                for (int j = 0; j < forest.Length; j++)//individual
                {
                    if (i != j && forest[j] > 0) 
                    {
                        forest[j]--;
                    }
                }

                daysEnd++;
                if (forest.Max().Equals(0)) //All days equals 0
                {
                    break;
                }
            }

            if (forest.Max().Equals(0)) //all days equals 0
            {
                break;
            }
            
            for (int i = 0; i < forest.Length; i++) //End of seasons
            {
                if (forest[i] > 0)
                {
                    forest[i]++;                    
                }
            }

            seasons++; // Added seasens
        }

        Console.WriteLine($"survived {daysEnd} days ({seasons} season)");
    }
}