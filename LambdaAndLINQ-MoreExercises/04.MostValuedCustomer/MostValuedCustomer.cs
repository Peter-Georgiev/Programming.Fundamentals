using System;
using System.Collections.Generic;
using System.Linq;

class MostValuedCustomer
{
    static void Main()
    {
        var productsPrices = new Dictionary<string, decimal>();
        var customersAndProducts = new Dictionary<string, Dictionary<string[], decimal[]>>();

        InsertProductsAndPrices(productsPrices);

        InsertCustomersAndProducts(productsPrices, customersAndProducts);

        PrintResult(productsPrices);
    }

    private static void InsertCustomersAndProducts(
        Dictionary<string, decimal> productsPrices, 
        Dictionary<string, Dictionary<List<string>, List<decimal>>> customersAndProducts)
    {

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.ToLower().Equals("print"))
            {
                break;
            }
            else if (readLine.ToLower().Equals("discount"))
            {

            }
            else
            {
                string[] tokens = readLine
                    .Split(new char[] { ' ', ':', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string customer = tokens[0];

                for (int i = 1; i < tokens.Length; i++)
                {
                    string product = tokens[i];

                    if (productsPrices.ContainsKey(product))
                    {
                        if (!customersAndProducts.ContainsKey(customer))
                        {
                            customersAndProducts.Add(customer, 
                                new Dictionary<List<string>, List<decimal>>());
                            customersAndProducts[customer].Add(new List<string>, new List<decimal>());
                        }

                        var selectProductAndPrice = productsPrices
                            .Where(x => x.Key.Equals(product));
                        string selectProduct = string.Empty;
                        decimal selectPrice = 0m;

                        foreach (var kvp in selectProductAndPrice)
                        {
                            selectProduct = kvp.Key;
                            selectPrice = kvp.Value;
                        }

                       // customersAndProducts[customer].Add(selectProduct);


                        Console.WriteLine();
                    }
                }
            }
        }
    }

    private static void PrintResult(Dictionary<string, decimal> productsPrices)
    {
        throw new NotImplementedException();
    }

    private static void InsertProductsAndPrices(Dictionary<string, decimal> productsPrices)
    {
        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.ToLower().Equals("shop is open"))
            {
                break;
            }

            string[] tokens = readLine
                .Split(' ')
                .ToArray();
            string name = tokens[0];
            decimal price = decimal.Parse(tokens[1]);

            if (!productsPrices.ContainsKey(name))
            {
                productsPrices.Add(name, price);
            }
        }
    }
}