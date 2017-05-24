using System;
class RestaurantDiscount
{
    static void Main()
    {
        int groupSize = int.Parse(Console.ReadLine());
        string hallName = Console.ReadLine();

        string messages;
        double price = 0;
        if (groupSize > 120)
        {
            messages = "We do not have an appropriate hall.";
        }
        else if (groupSize == 90)
        {
            price = ReturnServicePackage(hallName, 5000d) / groupSize;
            messages = $"We can offer you the Terrace";
        }
        else if (groupSize > 75)
        {
            price = ReturnServicePackage(hallName, 7500d) / groupSize;
            messages = $"We can offer you the Great Hall";
        }
        else if (groupSize > 50)
        {
            price = ReturnServicePackage(hallName, 5000d) / groupSize;
            messages = $"We can offer you the Terrace";
        }
        else
        {
            price = ReturnServicePackage(hallName, 2500d) / groupSize;
            messages = $"We can offer you the Small Hall";
        }

        Console.WriteLine(messages);
        if (price != 0)
        {
            Console.WriteLine($"The price per person is {price:F2}$");
        }

    }

    public static double ReturnServicePackage(string name, double price)
    {
        double result = 0;
        switch (name)
        {
            case "Normal":
                result =  (price + 500d) *0.05d;
                result = (price + 500d) - result;
                break;
            case "Gold":
                result = (price + 750d) * 0.10d;
                result = (price + 750d) - result;
                break;
            case "Platinum":
                result = (price + 1000d) * 0.15d;
                result = (price + 1000d) - result;
                break;
            default:
                break;
        }
        return result;
    }
}