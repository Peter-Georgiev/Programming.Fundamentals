using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class GroceryShop
{
    static void Main()
    {
        Dictionary<string, decimal> database =
            new Dictionary<string, decimal>();

        InsertDatabase(database);

        PrintDatabase(database);
    }

    static void InsertDatabase(Dictionary<string, decimal> database)
    {
        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("bill"))
            {
                break;
            }

            Match regex = Regex.Match(readLine, @"^(?<product>[A-Z][a-z]+):(?<price>\d+\.\d{2})$");
            if (!regex.Success)
            {
                continue;
            }

            string product = regex.Groups["product"].Value.Trim();
            decimal price = decimal.Parse(regex.Groups["price"].Value.Trim());

            if (!database.ContainsKey(product))
            {
                database.Add(product, price);
            }

            database[product] = price;            
        }
    }

    static void PrintDatabase(Dictionary<string, decimal> database)
    {
        var sortData = database
            .OrderByDescending(x => x.Value);

        foreach (var p in sortData)
        {
            Console.WriteLine($"{p.Key} costs {p.Value:F2}");
        }
    }
}