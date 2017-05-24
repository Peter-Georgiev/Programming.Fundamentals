using System;

class MilesToKilometers
{
    static void Main()
    {
        decimal miles = decimal.Parse(Console.ReadLine());

        decimal convertToKilom = miles * 1.60934m;

        Console.WriteLine($"{convertToKilom:F2}");
    }
}