using System;

class HornetWings
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        decimal m = decimal.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());

        decimal distance = (n / 1000m) * m;
        
        decimal seconds = ((n / p) * 5) + (n / 100m);

        Console.WriteLine($"{distance:F2} m.");
        Console.WriteLine($"{seconds} s.");
    }
}