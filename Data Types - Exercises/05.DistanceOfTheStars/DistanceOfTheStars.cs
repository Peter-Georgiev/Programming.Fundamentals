using System;

class DistanceOfTheStars
{
    static void Main()
    {
        decimal proxima = 9450000000000m * 4.22m;
        decimal centerOfGalaxy = 9450000000000m * 26000m;
        decimal diameterOfMilky = 9450000000000m * 100000m;
        decimal distanceFromEarth = 9450000000000m * 46500000000m;

        Console.WriteLine($"{proxima.ToString("e2")}");
        Console.WriteLine($"{centerOfGalaxy.ToString("e2")}");
        Console.WriteLine($"{diameterOfMilky.ToString("e2")}");
        Console.WriteLine($"{distanceFromEarth.ToString("e2")}");
    }
}