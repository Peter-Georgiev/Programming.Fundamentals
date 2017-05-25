using System;

class Megapixels
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());

        double megapixels = Math.Round(((double)width * (double)height) / 1000000d, 1);

        Console.WriteLine($"{width}x{height} => {megapixels}MP");
    }
}