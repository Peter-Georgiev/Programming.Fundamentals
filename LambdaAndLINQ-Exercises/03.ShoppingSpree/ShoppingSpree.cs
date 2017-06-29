using System;
using System.Collections.Generic;
using System.Linq;

class ShoppingSpree
{
    static void Main()
    {
        Dictionary<string, decimal> dictionary = new Dictionary<string, decimal>();        

        decimal budget = decimal.Parse(Console.ReadLine());

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("end"))
            {
                break;
            }
            else
            {
                string[] input = readLine
                    .Split(' ')
                    .ToArray();

                string product = input[0];
                decimal price = decimal.Parse(input[1]);

                if (!dictionary.ContainsKey(product))
                {
                    dictionary.Add(product, price);
                }
                else
                {
                    Dictionary<string, decimal> tempDic = dictionary
                        .Where(x => x.Key == product)
                        .Where(x => x.Value > price)
                        .ToDictionary(x => x.Key, x => price);

                    foreach (var kvp in tempDic)
                    {
                        dictionary[kvp.Key] = kvp.Value;
                    }                    
                }
            } 
        }

        if (budget >= dictionary.Sum(x => x.Value))
        {
            dictionary
                .OrderBy(x => x.Key.Length)
                .OrderByDescending(x => x.Value)                
                .ToList()
                .ForEach(x => Console.WriteLine("{0} costs {1:F2}", x.Key, x.Value));   
        }
        else
        {
            Console.WriteLine("Need more money... Just buy banichka");
        }
    }
}