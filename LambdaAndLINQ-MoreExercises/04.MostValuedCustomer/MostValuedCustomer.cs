using System;
using System.Collections.Generic;
using System.Linq;

class MostValuedCustomer
{
    static void Main()
    {
        var data = new Dictionary<string, double>();

        string readLine = Console.ReadLine();
        while (readLine != "Shop is open")
        {
            InsertProductsAndPrices(data, readLine);
            readLine = Console.ReadLine();
        }

        var customers = new Dictionary<string, Dictionary<string, double>>();

        readLine = Console.ReadLine();
        while (readLine != "Print")
        {
            if (readLine == "Discount")
            {
                DiscountProducts(data, customers);
            }
            else
            {
                InsertCustomersAndProducts(data, customers, readLine);
            }

            readLine = Console.ReadLine();
        }

        PrintResult(data, customers);
    }

    private static void PrintResult(Dictionary<string, double> data, Dictionary<string, Dictionary<string, double>> customers)
    {
        foreach (var kvp in data)
        {
            foreach (var kvpName in customers)
            {
                if (customers[kvpName.Key].ContainsKey(kvp.Key))
                {
                    customers[kvpName.Key][kvp.Key] *= kvp.Value;
                }
            }
        }

        customers = customers
            .OrderByDescending(name => name.Value.Sum(x => x.Value))
            .Take(1)
            .ToDictionary(x => x.Key, x => x.Value);

        double total = 0d;
        foreach (var kvpName in customers)
        {
            total = kvpName.Value
                .Select(x => x.Value)
                .Sum();
        }

        foreach (var kvp in data)
        {
            foreach (var kvpName in customers)
            {
                if (customers[kvpName.Key].ContainsKey(kvp.Key))
                {
                    customers[kvpName.Key][kvp.Key] = kvp.Value;
                }
            }
        }

        foreach (var kvpName in customers)
        {
            Console.WriteLine($"Biggest spender: {kvpName.Key}");
            Console.WriteLine("^Products bought:");                            

            var sortProduct = kvpName.Value
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvpProduct in sortProduct)
            {
                double productPrice = data
                    .Where(x => x.Key.Equals(kvpProduct.Key))
                    .Select(x => x.Value)
                    .Sum();

                Console.WriteLine($"^^^{kvpProduct.Key}: {productPrice:F2}");
            }

            Console.WriteLine($"Total: {total:F2}");
        }
    }

    private static void CalculateProducts(Dictionary<string, Dictionary<string, double>> customers, Dictionary<string, double> data)
    {
        throw new NotImplementedException();
    }

    static string[] TakeFirstThree(Dictionary<string, double> data)
    {
        data = data.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        return data.Keys.Take(3).ToArray();
    }

    private static void DiscountProducts(Dictionary<string, double> data, Dictionary<string, Dictionary<string, double>> customers)
    {
        string[] takeFirstThree = TakeFirstThree(data);

        for (int i = 0; i < takeFirstThree.Length; i++)
        {
            var key = takeFirstThree[i];
            data[key] = data[key] * 0.9;
        }
    }

    private static void InsertCustomersAndProducts(Dictionary<string, double> data, Dictionary<string, Dictionary<string, double>> customers, string readLine)
    {
        string[] tokens = readLine
            .Split(new char[] { ' ', ':', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string nameOfCustomer = tokens[0];

        for (int i = 1; i < tokens.Length; i++)
        {
            if (data.ContainsKey(tokens[i]))
            {
                if (!customers.ContainsKey(nameOfCustomer))
                {
                    customers.Add(nameOfCustomer, new Dictionary<string, double>());
                }

                if (!customers[nameOfCustomer].ContainsKey(tokens[i]))
                {
                    customers[nameOfCustomer].Add(tokens[i], 0);
                }

                customers[nameOfCustomer][tokens[i]]++;
            }
        }
    }

    private static void InsertProductsAndPrices(Dictionary<string, double> data, string readLine)
    {
        string[] tokens = readLine
            .Split(' ')
            .ToArray();
        string productName = tokens[0];
        double productPrice = double.Parse(tokens[1]);

        data.Add(productName, productPrice);
    }
}