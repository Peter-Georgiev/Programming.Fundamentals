using System;
using System.Collections.Generic;

class VaporStore
{
    static void Main()
    {
        double balance = double.Parse(Console.ReadLine());

        string line;
        string messages = "";
        double gamesPrice = 0;
        double price = balance;
        bool isExitPay = true;

        while (isExitPay)
        {
            line = Console.ReadLine();
            isExitPay = !line.Equals("Game Time");

            if (isExitPay)
            {
                if (balance <= 0 || price <= 0)
                {
                    messages = "Out of money!";
                    Console.WriteLine(messages);
                    return;
                }

                switch (line)
                {
                    case "OutFall 4":
                        gamesPrice = 39.99d;
                        messages = "Bought OutFall 4";
                        break;
                    case "CS: OG":
                        gamesPrice = 15.99d;
                        messages = "Bought CS: OG";
                        break;
                    case "Zplinter Zell":
                        gamesPrice = 19.99d;
                        messages = "Bought Zplinter Zell";
                        break;
                    case "Honored 2":
                        gamesPrice = 59.99d;
                        messages = "Bought Honored 2";
                        break;
                    case "RoverWatch":
                        gamesPrice = 29.99d;
                        messages = "Bought RoverWatch";
                        break;
                    case "RoverWatch Origins Edition":
                        gamesPrice = 39.99d;
                        messages = "Bought RoverWatch Origins Edition";
                        break;
                    default:
                        messages = "Not Found";
                        break;
                }

                if (gamesPrice > price && !messages.Equals("Not Found"))
                {
                    messages = "Too Expensive";                    
                }
                else if (price >= gamesPrice && !gamesPrice.Equals(0) && !messages.Equals("Not Found"))
                {
                    price -= gamesPrice;                   
                }

                Console.WriteLine(messages);

                if (price <= 0)
                {
                    messages = "Out of money!";
                    Console.WriteLine(messages);
                    return;
                }
            }
        }
        Console.WriteLine($"Total spent: ${balance - price:F2}. Remaining: ${price:F2}");
    }
}