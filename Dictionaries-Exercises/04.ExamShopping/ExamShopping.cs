using System;
using System.Collections.Generic;

class ExamShopping
{
    static void Main()
    {
        var productQuantity = new Dictionary<string, long>();

        var readLine = Console.ReadLine();

        readLine = GetShopingTime(productQuantity, readLine);

        readLine = Console.ReadLine();

        readLine = GetExamTime(productQuantity, readLine);

        PrintProductQuantity(productQuantity);
    }

    private static string GetShopingTime(Dictionary<string, long> productQuantity, string readLine)
    {
        while (!readLine.Equals("shopping time"))
        {
            var tokens = readLine.Split(' ');
            var product = tokens[1];
            var quantity = tokens[2];

            //int.TryParse(quantity, out int n);

            if (tokens[0].Equals("stock") && int.TryParse(quantity, out int n))
            {
                if (!productQuantity.ContainsKey(product))
                {
                    productQuantity.Add(product, 0);
                }

                productQuantity[product] += n;
            }           

            readLine = Console.ReadLine();
        }

        return readLine;
    }

    private static string GetExamTime(Dictionary<string, long> productQuantity, string readLine)
    {
        while (!readLine.Equals("exam time"))
        {
            var tokens = readLine.Split(' ');
            var product = tokens[1];
            var quantity = tokens[tokens.Length - 1];

            if (productQuantity.ContainsKey(product) && int.TryParse(quantity, out int n))
            {
                if (productQuantity[product] <= 0)
                {
                    Console.WriteLine($"{product} out of stock");
                    productQuantity[product] = 0;
                }
                else
                {
                    productQuantity[product] -= n;

                    if (productQuantity[product] < 0)
                    {
                        productQuantity[product] = 0;
                    }
                }
            }
            else
            {
                Console.WriteLine($"{product} doesn't exist");
            }

            readLine = Console.ReadLine();
        }

        return readLine;
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