using System;

class CharacterStats
{
    static void Main()
    {
        string name = Console.ReadLine();
        int currentHealth = int.Parse(Console.ReadLine());
        int maxHealth = int.Parse(Console.ReadLine());
        int currentEnergy = int.Parse(Console.ReadLine());
        int maxEnergy = int.Parse(Console.ReadLine());

        Console.WriteLine($"Name: {name}");
        Console.Write($"Health: ");
        Console.Write($"|{new string('|', currentHealth)}");
        Console.WriteLine($"{new string('.', maxHealth - currentHealth)}|");
        Console.Write($"Energy: ");
        Console.Write($"|{new string('|', currentEnergy)}");
        Console.WriteLine($"{new string('.', maxEnergy - currentEnergy)}|");
    }
}