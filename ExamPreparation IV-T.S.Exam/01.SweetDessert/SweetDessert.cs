using System;

class SweetDessert
{
    static void Main()
    {
        decimal amountOfCash = decimal.Parse(Console.ReadLine());
        int numberOfGuests = int.Parse(Console.ReadLine());
        decimal priceOfBananas = decimal.Parse(Console.ReadLine());
        decimal priceOfEggs = decimal.Parse(Console.ReadLine());
        decimal priceOfBerries = decimal.Parse(Console.ReadLine());

        decimal portions = Math.Ceiling(numberOfGuests / 6m);
        decimal calculatedPrice = portions * ((2 * priceOfBananas) + 
            (4 * priceOfEggs) + (0.2m * priceOfBerries));

        if (calculatedPrice > amountOfCash)
        {
            Console.WriteLine($"Ivancho will have to withdraw money - " +
                $"he will need {calculatedPrice - amountOfCash:F2}lv more. ");
        }
        else
        {
            Console.WriteLine($"Ivancho has enough money - it would cost " +
                $"{calculatedPrice:F2}lv.");
        }
    }
}