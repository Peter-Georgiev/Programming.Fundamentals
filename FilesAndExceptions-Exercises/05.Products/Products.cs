using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Products
{
    static void Main()
    {
        string baseProducts = @"products.txt";
        var baseDic = 
            new Dictionary<string, Dictionary<string, Dictionary<int, decimal>>>();

        ReadProductsFile(baseDic, baseProducts);

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("exit"))
            {
                break;
            }
            else if (readLine.Equals("stock"))
            {
                AddedProductsFile(baseDic, baseProducts);
            }
            else if (readLine.Equals("analyze"))
            {
                AnalyzeProducts(baseDic, baseProducts);
            }
            else if (readLine.Equals("sales"))
            {
                SalesPrintProdcts(baseDic);
            }
            else
            {
                ReadProductInputLine(baseDic, readLine);
            }
        }
    }

    private static void AnalyzeProducts(Dictionary<string, Dictionary<string, Dictionary<int, decimal>>> baseDic, string baseProducts)
    {
        var analyzeBase = new Dictionary<string, Dictionary<string, Dictionary<int, decimal>>>();

        ReadProductsFile(analyzeBase, baseProducts);

        if (analyzeBase.Count.Equals(0))
        {
            Console.WriteLine("No products stocked");
        }
        else
        {
            analyzeBase = analyzeBase
            .OrderBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in analyzeBase)
            {
                foreach (var kvpName in kvp.Value)
                {
                    string name = kvpName.Key;
                    string type = kvp.Key;

                    Console.WriteLine($"{type}, Product: {name}");

                    foreach (var kvpQuantity in kvpName.Value)
                    {
                        decimal price = kvpQuantity.Value;
                        int quantity = kvpQuantity.Key;

                        Console.WriteLine($"Price: ${price:F2}, Amount Left: {quantity}");
                    }
                }
            }
        }        
    }

    private static void SalesPrintProdcts(Dictionary<string, Dictionary<string, Dictionary<int, decimal>>> baseDic)
    {
        var salesProducts = new Dictionary<string, decimal>();

        foreach (var kvp in baseDic)
        {
            string type = kvp.Key;
            decimal income = 0m;

            foreach (var kvpName in kvp.Value)
            {
                foreach (var kvpQuantity in kvpName.Value)
                {
                    income += kvpQuantity.Key * kvpQuantity.Value;
                }
            }

            if (!salesProducts.ContainsKey(type))
            {
                salesProducts.Add(type, income);
            }
        }

        salesProducts
            .OrderByDescending(x => x.Value)
            .ToList()
            .ForEach(x => Console.WriteLine($"{x.Key}: ${x.Value:F2}"));
    }

    private static void AddedProductsFile(Dictionary<string, Dictionary<string, Dictionary<int, decimal>>> baseDic, string baseProducts)
    {
        File.WriteAllText(baseProducts, String.Empty);

        foreach (var kvp in baseDic)
        {
            foreach (var kvpName in kvp.Value)
            {
                string name = $"'{kvpName.Key}'\t";
                File.AppendAllText(baseProducts, name);
                string type = $"'{kvp.Key}'\t";
                File.AppendAllText(baseProducts, type);

                foreach (var kvpQuantity in kvpName.Value)
                {
                    string price = Convert.ToString($"'{kvpQuantity.Value}'\t");
                    File.AppendAllText(baseProducts, price);
                    string quantity = Convert.ToString($"'{kvpQuantity.Key}'\t" + Environment.NewLine);
                    File.AppendAllText(baseProducts, quantity);
                }
            }
        }
    }

    private static void ReadProductsFile(Dictionary<string, Dictionary<string, Dictionary<int, decimal>>> baseDic, string baseProducts)
    {
        bool hasProductsFile = File.Exists(baseProducts);

        if (hasProductsFile)
        {
            string[] tokensLine = File.ReadAllLines(baseProducts);

            if (tokensLine.Length > 0)
            {
                for (int i = 0; i < tokensLine.Length; i++)
                {
                    string[] tokens = tokensLine[i]
                        .Split(new[] { '\'', '\t', '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    InsertBaseDic(baseDic, tokens);
                }
            }
        }
    }

    private static void ReadProductInputLine(Dictionary<string, Dictionary<string, Dictionary<int, decimal>>> baseDic, string readLine)
    {
        string[] tokens = readLine.Split(' ').ToArray();

        InsertBaseDic(baseDic, tokens);
    }

    private static void InsertBaseDic(Dictionary<string, Dictionary<string, Dictionary<int, decimal>>> baseDic, string[] tokens)
    {
        string type = tokens[1];
        string name = tokens[0];
        int quantity = int.Parse(tokens[3]);
        decimal price = decimal.Parse(tokens[2]);

        if (!baseDic.ContainsKey(type))
        {
            baseDic.Add(type, new Dictionary<string, Dictionary<int, decimal>>());
        }

        if (!baseDic[type].ContainsKey(name))
        {
            baseDic[type].Add(name, new Dictionary<int, decimal>());
        }

        if (!baseDic[type][name].ContainsKey(quantity))
        {
            baseDic[type][name].Add(quantity, price);
        }

        foreach (var kvp in baseDic)
        {
            if (kvp.Key.Equals(type))
            {
                foreach (var kvpName in kvp.Value)
                {
                    if (kvpName.Key.Equals(name))
                    {
                        kvpName.Value.Clear();

                        baseDic[type][name][quantity] = price;
                    }
                }
            }
        }
    }
}