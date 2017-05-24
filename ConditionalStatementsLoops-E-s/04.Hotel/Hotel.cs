using System;

class Hotel
{
    static void Main()
    {
        string month = Console.ReadLine();
        int night = int.Parse(Console.ReadLine());

        double priceStudio = 0;
        double priceDouble = 0;
        double priceSuite = 0;

        bool isTrue = month.Equals("May") || month.Equals("October") || month.Equals("June") ||
            month.Equals("September") || month.Equals("July") || month.Equals("August") ||
            month.Equals("December") || night >= 0 || night <= 200;

        if ((month.Equals("May") || month.Equals("October")) && isTrue)
        {
            priceStudio = (night * 50d);
            priceDouble = (night * 65d);
            priceSuite = (night * 75d);

            if (night > 7 && month.Equals("May"))
            {
                priceStudio *= 0.95d;
            }

            if (night > 7 && month.Equals("October"))
            {
                priceStudio -= 50d;
                priceStudio *= 0.95d;
            }
        }
        else if ((month.Equals("June") || month.Equals("September")) && isTrue)
        {
            priceStudio = (night * 60d);
            priceDouble = (night * 72d);
            priceSuite = (night * 82d);

            if (night > 14)
            {
                priceDouble *= 0.90d;
            }

            if (night > 7 && month.Equals("September"))
            {
                priceStudio -= 60d;
            }

        }
        else if ((month.Equals("July") || month.Equals("August") || month.Equals("December")) && isTrue)
        {
            priceStudio = (night * 68d);
            priceDouble = (night * 77d);
            priceSuite = (night * 89d);

            if (night > 14)
            {
                priceSuite *= 0.85d;
            }           
        }

        Console.WriteLine($"Studio: {priceStudio:F2} lv.");
        Console.WriteLine($"Double: {priceDouble:F2} lv.");
        Console.WriteLine($"Suite: {priceSuite:F2} lv.");
    }
}