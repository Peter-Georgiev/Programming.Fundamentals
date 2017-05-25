using System;
using System.Collections.Generic;

class CakeIngredients
{
    static void Main()
    {
        string ingredients = Console.ReadLine();

        int count = 0;
        List<string> addingIngredients = new List<string>();

        while (ingredients != "Bake!")
        {
            count++;
            addingIngredients.Add(ingredients);            
            ingredients = Console.ReadLine();
        }

        if (addingIngredients[0].Equals("Flour") && addingIngredients.Count == 1 && ingredients.Equals("Bake!"))
        {
            Console.WriteLine($"Preparing cake with {count} ingredients.");
        }
        else if (addingIngredients[0].Equals("Flour") && addingIngredients[1].Equals("Bread") &&
            addingIngredients[2].Equals("Sugar") && addingIngredients[3].Equals("Butter") &&
            addingIngredients.Count == 4 && ingredients.Equals("Bake!"))
        {
            for (int i = 0; i < addingIngredients.Count; i++)
            {                
                if (i < addingIngredients.Count - 1)
                {
                    Console.WriteLine($"Adding ingredient {addingIngredients[i]}.");
                }
                else
                {
                    count++;
                    Console.Write($"Adding ingredient {addingIngredients[i]}.");
                    Console.WriteLine($" Preparing cake with {count} ingredients.");
                }
            }
        }
        else
        {
            foreach (var item in addingIngredients)
            {
                Console.WriteLine($"Adding ingredient {item}.");
            }

            Console.WriteLine($"Preparing cake with {count} ingredients.");
        }        
    }
}