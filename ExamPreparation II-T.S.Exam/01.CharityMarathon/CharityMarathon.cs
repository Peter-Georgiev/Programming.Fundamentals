using System;

class CharityMarathon
{
    static void Main()
    {
        long days = int.Parse(Console.ReadLine()); //range [0 … 365]
        long participate = long.Parse(Console.ReadLine()); //range [0 … 2,147,483,647]
        int laps = int.Parse(Console.ReadLine()); //range [0 … 100]
        long lengthTrack = long.Parse(Console.ReadLine()); //[0 … 2,147,483,647]
        long capacityTrack = int.Parse(Console.ReadLine()); //range [0 … 1000]
        decimal moneyKm = decimal.Parse(Console.ReadLine()); //floating point number

        long maxRunners = capacityTrack * days;

        long minRunners = Math.Min(maxRunners, participate);

        long totalKilometers = (minRunners * laps * lengthTrack) / 1000;

        decimal moneyRaised = totalKilometers * moneyKm;

        Console.WriteLine($"Money raised: {moneyRaised:F2}");
    }
}