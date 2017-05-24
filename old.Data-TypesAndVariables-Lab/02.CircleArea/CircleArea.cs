using System;

class CircleArea
{
    static void Main()
    {
        double r = double.Parse(Console.ReadLine());

        double area = Math.PI * r * r;

        Console.WriteLine($"{area:F12}");

    }
}