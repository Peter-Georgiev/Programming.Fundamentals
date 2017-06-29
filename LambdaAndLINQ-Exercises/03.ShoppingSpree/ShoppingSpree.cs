using System;
using System.Collections.Generic;
using System.Linq;

class ShoppingSpree
{
    static void Main()
    {
        Dictionary<string, double> dictionary = new Dictionary<string, double>();

        double budget = double.Parse(Console.ReadLine());
        double sum = 0;

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.ToLower().Equals("end"))
            {
                break;
            }
            else
            {
                string[] input = readLine
                    .Split(' ')
                    .ToArray();

                string key = input[0];
                double value = double.Parse(input[1]);

                if (!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, value);
                }

                foreach (var item in dictionary)
                {
                    if (item.Key == key)
                    {
                        if (item.Value > value)
                        {
                            dictionary[key] = value;
                            break;
                        }
                    }
                }
            }

            sum = dictionary.Sum(x => x.Value);
        }

        if (budget >= sum && sum != 0)
        {
            dictionary
                .OrderByDescending(x => x.Value)
                .OrderByDescending(x => x.Key)
                .ToList()
                .ForEach(x => Console.WriteLine("{0} costs {1:F2}", x.Key, x.Value));
                
        }
        else
        {
            Console.WriteLine("Need more money... Just buy banichka");
        }
    }
}