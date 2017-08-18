using System;

class SplinterTrip
{
    static void Main()
    {
        decimal tripDistance = decimal.Parse(Console.ReadLine());
        decimal fuelTank = decimal.Parse(Console.ReadLine());
        decimal milesSpentInHeavyWinds = decimal.Parse(Console.ReadLine());
        
        decimal nonHeavyWindsConsumption = (tripDistance - milesSpentInHeavyWinds) * 25;
        decimal heavyWindsConsumption = milesSpentInHeavyWinds * (25 * 1.5m);
        decimal fuelConsumption = nonHeavyWindsConsumption + heavyWindsConsumption;
        decimal totalFuelConsumption = fuelConsumption + (fuelConsumption * 0.05m);

        Console.WriteLine($"Fuel needed: {totalFuelConsumption:F2}L");

        if (totalFuelConsumption > fuelTank)
        {
            Console.WriteLine($"We need {totalFuelConsumption - fuelTank:F2}L more fuel.");
        }
        else
        {
            Console.WriteLine($"Enough with {fuelTank - totalFuelConsumption:F2}L to spare!");
        }
    }
} 