using ReportSale;
using System;
using System.Collections.Generic;

class SalesReport
{
    static void Main()
    {
        var n = byte.Parse(Console.ReadLine());
        
        var result = new SortedDictionary<string, decimal>();

        for (byte i = 0; i < n; i++)
        {
            var currentSaleAsString = Console.ReadLine();
            var currentSale = Sale.Parse(currentSaleAsString);

            if (!result.ContainsKey(currentSale.Town))
            {
                result[currentSale.Town] = 0;
            }

            result[currentSale.Town] +=
                currentSale.Quantity * currentSale.Price;
        }

        foreach (var kvp in result)
        {
            Console.WriteLine("{0} -> {1:F2}", kvp.Key, kvp.Value);
        }
    }
}

//internal class Sale
//{
//    public string Town { get; set; }

//    public string Product { get; set; }

//    public decimal Price { get; set; }

//    public decimal Quantity { get; set; }

//    public static Sale Parse(string saleAsString)
//    {
//        var saleParts = saleAsString.Split(' ');

//        return new Sale
//        {
//            Town = saleParts[0],
//            Product = saleParts[1],
//            Price = decimal.Parse(saleParts[2]),
//            Quantity = decimal.Parse(saleParts[3])
//        };
//    }
//}