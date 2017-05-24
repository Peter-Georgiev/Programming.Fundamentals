using System;

class BeverageLabels
{
    static void Main()
    {
        string name = Console.ReadLine();
        int volume = int.Parse(Console.ReadLine());
        int energy = int.Parse(Console.ReadLine());
        int sugar = int.Parse(Console.ReadLine());

        double energyContent = (volume * energy) / 100d;
        double sugarContent = (volume * sugar) / 100d;
        Console.WriteLine($"{volume}ml {name}:");
        Console.WriteLine($"{energyContent}kcal, {sugarContent}g sugars");
    }
}