using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        checked
        {
            Dictionary<string, decimal> result = new Dictionary<string, decimal>
            {
                { "Technical", 0 },
                { "Theoretical", 0 },
                { "Practical", 0 }
            };

            int n = int.Parse(Console.ReadLine());
            while (n > 0)
            {
                int distanceToTravelMiles = int.Parse(Console.ReadLine());
                decimal cargoBeingCarriedTones = decimal.Parse(Console.ReadLine());
                string team = Console.ReadLine();

                long distanceInMeters = distanceToTravelMiles * 1600L;
                decimal cargoInKillograms = cargoBeingCarriedTones * 1000m;
                decimal participantEarnedMoney =
                    (cargoInKillograms * 1.5m) - (0.7m * distanceInMeters * 2.5m);

                if (result.ContainsKey(team))
                {
                    result[team] += participantEarnedMoney;
                }

                n--;
            }

            foreach (var kvp in result.OrderByDescending(x => x.Value).Take(1))
            {
                Console.WriteLine($"The {kvp.Key} Trainers win with ${kvp.Value:F3}.");
            }
        }
    }
}