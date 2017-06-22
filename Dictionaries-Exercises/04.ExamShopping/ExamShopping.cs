using System;
using System.Collections.Generic;

class ExamShopping
{
    static void Main()
    {
        var productQuantity = new Dictionary<string, long>();

        var readLine = Console.ReadLine();

        GetShopingTime(productQuantity, readLine);

        readLine = Console.ReadLine();

        GetExamTime(productQuantity, readLine);

        PrintProductQuantity(productQuantity);
    }

    private static void GetShopingTime(Dictionary<string, long> productQuantity, string readLine)
    {
        while (!readLine.Equals("shopping time"))
        {
            var tokens = readLine.Split();
            var type = tokens[0];
            var product = tokens[1];
            var quantity = tokens[2];

            int.TryParse(quantity, out int n);

            if (!productQuantity.ContainsKey(product))
            {
                productQuantity.Add(product, 0);
            }

            productQuantity[product] += n;

            readLine = Console.ReadLine();
        }
    }

    private static void GetExamTime(Dictionary<string, long> productQuantity, string readLine)
    {
        while (!readLine.Equals("exam time"))
        {
            var tokens = readLine.Split();
            var type = tokens[0];
            var product = tokens[1];
            var quantity = tokens[2];

            if (!productQuantity.ContainsKey(product))
            {
                Console.WriteLine($"{product} doesn't exist");
            }
            else if (productQuantity.ContainsKey(product) && productQuantity[product] == 0)
            {
                Console.WriteLine($"{product} out of stock");
            }
            else
            {
                int.TryParse(quantity, out int n);
                productQuantity[product] -= n;

                if (productQuantity[product] < 0)
                {
                    productQuantity[product] = 0;
                }
            }

            readLine = Console.ReadLine();
        }
    }
    
    private static void PrintProductQuantity(Dictionary<string, long> productQuantity)
    {
        foreach (var print in productQuantity)
        {
            if (print.Value > 0)
            {
                Console.WriteLine($"{print.Key} -> {print.Value}");
            }
        }
    }
}