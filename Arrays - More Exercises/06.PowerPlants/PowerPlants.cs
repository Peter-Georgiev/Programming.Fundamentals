using System;
using System.Linq;

class PowerPlants
{
    static void Main()
    {
        int[] flowers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int daysEnd = 0;
        int seasons = 0;

        while (flowers.Max() != 0)
        {

            for (int i = 0; i < flowers.Length; i++) //days flowers
            {
                for (int j = 0; j < flowers.Length; j++) //individual flowers
                {
                    if (i != j && flowers[j] > 0)
                    {
                        flowers[j]--;
                    }
                }

                daysEnd++;
                if (flowers.Max() == 0)
                {
                    break;
                }
            }

            if (flowers.Max() == 0)
            {
                break;
            }

            // End of season
            for (int i = 0; i < flowers.Length; i++)
            {
                if (flowers[i] > 0)
                {
                    flowers[i]++;
                }
            }

            seasons++;
        }

        Console.WriteLine($"survived {daysEnd} i ({seasons} seasons)");
    }
}