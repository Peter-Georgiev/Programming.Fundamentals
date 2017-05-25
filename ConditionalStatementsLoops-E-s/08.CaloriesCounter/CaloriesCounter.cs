using System;

class CaloriesCounter
{
    static void Main()
    {
        int countLine = int.Parse(Console.ReadLine());

        string[] ingredients = new string[countLine];

        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i] = Console.ReadLine();
        }

        int countCalories = 0;
        for (int i = 0; i < ingredients.Length; i++)
        {
            switch (ingredients[i].ToLower())
            {
                case "cheese":
                    countCalories += 500;
                    break;
                case "tomato sauce":
                    countCalories += 150;
                    break;
                case "salami":
                    countCalories += 600;
                    break;
                case "pepper":
                    countCalories += 50;
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine($"Total calories: {countCalories}");
    }
}