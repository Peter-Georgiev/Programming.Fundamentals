using System;
using System.Text.RegularExpressions;
using System.Linq;

class EnduranceRally
{
    static void Main()
    {
        string[] driversName = Regex.Split(Console.ReadLine(), @"\s+")
            .Where(x => x.Length > 0)
            .ToArray();
        double[] zonesNumbers = Regex.Split(Console.ReadLine(), @"\s+")
            .Where(x => x.Length > 0)
            .Select(x => double.Parse(x.Trim()) * -1)
            .ToArray();
        int[] indexes = Regex.Split(Console.ReadLine(), @"\s+")
            .Where(x => x.Length > 0)
            .Select(int.Parse)
            .Distinct()
            .Where(x => x >= 0 && x <= zonesNumbers.Length - 1)
            .ToArray();
        
        foreach (var index in indexes)
        {
            zonesNumbers[index] *= -1;
        }

        foreach (var driver in driversName)
        {
            double fuel = (double)driver[0];
            for (int i = 0; i < zonesNumbers.Length; i++)
            {
                fuel += zonesNumbers[i];
                if (fuel <= 0)
                {
                    Console.WriteLine($"{driver} - reached {i}");
                    break;
                }
            }
            
            if (fuel > 0)
            {
                Console.WriteLine($"{driver} - fuel left {fuel:F2}");
            }
        }
    }
}