using System;

class FloatOrInteger
{
    static void Main()
    {
        double number = double.Parse(Console.ReadLine());

        Console.WriteLine($"{Math.Round(number)}");
    }
}