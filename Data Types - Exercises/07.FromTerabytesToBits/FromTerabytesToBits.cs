using System;

class FromTerabytesToBits
{
    static void Main()
    {
        double bits = double.Parse(Console.ReadLine());

        double convertToTB = bits * 8796093022208;
        Console.WriteLine(convertToTB);
    }
}