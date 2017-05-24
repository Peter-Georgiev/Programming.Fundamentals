using System;

class CakeIngredients
{
    static void Main()
    {
        string ingredients = Console.ReadLine();

        int count = 0;
        while (ingredients != "Bake!")
        {
            count++;
            Console.WriteLine($"Adding ingredient {ingredients}.");
            ingredients = Console.ReadLine();
        }
        count++;
        Console.WriteLine($"Preparing cake with {count} ingredients.");
    }
}