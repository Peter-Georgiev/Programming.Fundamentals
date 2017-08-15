using System;
using System.Linq;

class EnduranceRally
{
    static void Main()
    {
        string[] tokensDrivers = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
        double[] zones = Console.ReadLine()
                    .Split(' ')
                    .Select(double.Parse)
                    .Select(x => x *= -1)
                    .ToArray();
        int[] indexes = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .Distinct()
                    .Where(x => x >= 0 && x < zones.Length)
                    .ToArray();

        foreach (var i in indexes)
        {
            zones[i] *= -1;
        }

        for (int i = 0; i < tokensDrivers.Length; i++)
        {
            double fuel = (double)tokensDrivers[i][0];

            for (int z = 0; z < zones.Length; z++)
            {
                fuel += zones[z];

                if (fuel <= 0)
                {
                    Console.WriteLine($"{tokensDrivers[i]} - reached {z}");
                    break;
                }
            }

            if (fuel > 0)
            {
                Console.WriteLine($"{tokensDrivers[i]} - fuel left {fuel:F2}");
            }
        }
    }
}