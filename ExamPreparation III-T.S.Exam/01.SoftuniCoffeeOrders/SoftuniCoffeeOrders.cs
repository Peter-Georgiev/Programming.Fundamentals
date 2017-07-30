using System;
using System.Globalization;

class SoftuniCoffeeOrders
{
    static void Main()
    {
        decimal totalPrice = 0.00m;
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
            string[] date = Console.ReadLine().Split('/');
            // DateTime date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", provider);
            int capsulesCount = int.Parse(Console.ReadLine());

            int daysInMonth = DateTime.DaysInMonth(int.Parse(date[2]), int.Parse(date[1]));

            decimal price = (((decimal)daysInMonth * (decimal)capsulesCount) * pricePerCapsule);
            totalPrice += price;
            Console.WriteLine($"The price for the coffee is: ${price:F2}");
        }

        Console.WriteLine($"Total: ${totalPrice:F2}");
    }
}