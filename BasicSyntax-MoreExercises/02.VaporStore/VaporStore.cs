using System;
using System.Collections.Generic;

class VaporStore
{
    static void Main()
    {
        double balance = double.Parse(Console.ReadLine());
        string line;
        string messages;
        double price = balance;
        double pay = balance;
        bool isExitPay = true;

        while (isExitPay)
        {
            line = Console.ReadLine();
            isExitPay = !line.Equals("Game Time");
            if (isExitPay)
            {
                switch (line)
                {
                    case "OutFall 4":
                        price -= 39.99d;
                        messages = "Bought OutFall 4";
                        break;
                    case "CS: OG":
                        price -= 15.99d;
                        messages = "Bought CS: OG";
                        break;
                    case "Zplinter Zell":
                        price -= 19.99d;
                        messages = "Bought Zplinter Zell";
                        break;
                    case "Honored 2":
                        price -= 59.99d;
                        messages = "Bought Honored 2";
                        break;
                    case "RoverWatch":
                        price -= 29.99d;
                        messages = "Bought RoverWatch";
                        break;
                    case "RoverWatch Origins Edition":
                        price -= 39.99d;
                        messages = "Bought RoverWatch Origins Edition";
                        break;
                    default:
                        messages = "Not Found";
                        break;
                }

                //pay -= price;
                if (price > balance && price > 0)
                {
                    messages = "Too Expensive";
                }
                else if (price <= 0)
                {
                    messages = "Out of money!";
                    isExitPay = false;
                }

                Console.WriteLine(messages);
            }
        }

        if (pay > 0)
        {

            Console.WriteLine($"Total spent: ${balance - price:F2}. Remaining: ${price:F2}");
        }
    }
}