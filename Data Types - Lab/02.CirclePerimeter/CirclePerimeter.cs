using System;

class CirclePerimeter
{
    static void Main()
    {
        double r = double.Parse(Console.ReadLine());
        Console.WriteLine($"{2 * Math.PI * r:F12}");
    }
}