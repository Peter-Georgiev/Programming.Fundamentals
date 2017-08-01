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

        decimal sets = Math.Ceiling(numberOfGuests / 6m);

        decimal price = sets * (2m * priceOfBananas) + sets * (4m * priceOfEggs) + sets * (0.2m * priceOfBerries);
        
        if (price <= amountOfCash)
        {
            Console.WriteLine($"Ivancho has enough money - it would cost {price:f2}lv.");
        }
        else
        {
            Console.WriteLine($"Ivancho will have to withdraw money - " +
                $"he will need {price - amountOfCash:f2}lv more.");
        }
    }
}