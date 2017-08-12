using System;

class SplinterTrip
{
    static void Main()
    {
        decimal tripDistanceMiles = decimal.Parse(Console.ReadLine());
        decimal fuelTankLiters = decimal.Parse(Console.ReadLine());
        decimal milesInHeavyWinds = decimal.Parse(Console.ReadLine());

        decimal milesNonHeavyWinds = (tripDistanceMiles - milesInHeavyWinds) * 25m;
        decimal litersHeavyWinds = milesInHeavyWinds * (25 * 1.5m);
        decimal totalLitersFuelConsumption = 
            (((milesNonHeavyWinds + litersHeavyWinds) * 5) / 100m) +
            (milesNonHeavyWinds + litersHeavyWinds);
        decimal remainingFuel = fuelTankLiters - totalLitersFuelConsumption;

        Console.WriteLine($"Fuel needed: {totalLitersFuelConsumption:F2}L");

        if (remainingFuel >= 0)
        {
            Console.WriteLine($"Enough with {remainingFuel:F2}L to spare!");
        }
        else
        {
            Console.WriteLine($"We need {Math.Abs(remainingFuel):F2}L more fuel.");
        }
    }
} 