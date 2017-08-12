using System;

class Wormtest
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        decimal width = decimal.Parse(Console.ReadLine());

        int convertCentimeters = length * 100;

        if (convertCentimeters == 0 || width == 0)
        {
            decimal result = convertCentimeters * width;
            Console.WriteLine($"{result:F2}");
            return;
        }

        decimal remainder = convertCentimeters % width;

        if (remainder == 0)
        {
            decimal result = convertCentimeters * width;
            Console.WriteLine($"{result:F2}");
        }
        else
        {
            decimal result = (convertCentimeters / width) * 100m;
            Console.WriteLine($"{result:F2}%");
        }
    }
}