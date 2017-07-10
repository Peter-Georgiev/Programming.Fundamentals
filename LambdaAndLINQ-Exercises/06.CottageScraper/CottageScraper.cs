using System;
using System.Collections.Generic;
using System.Linq;

class CottageScraper
{
    static void Main()
    {
        Dictionary<string, List<int>> dictionary = InsertTypesAndLenghts();

        string[] result = CalculatePriceMeterSubtotal(dictionary);

        PrintResult(result);
    }

    private static string[] CalculatePriceMeterSubtotal(Dictionary<string, List<int>> dictionary)
    {
        string[] result = new string[4];

        string[] typeAndLenght = ReadTypeAndMinLenghtTree();

        string typeTree = typeAndLenght[0];
        int lenghtTree = int.Parse(typeAndLenght[1]);

        double average = Math.Round(dictionary.SelectMany(x => x.Value).ToList().Average(), 2);

        double usedLongs = average * dictionary
            .Where(x => x.Key.Equals(typeTree))
            .ToDictionary(x => x.Key, x => x.Value)
            .SelectMany(x => x.Value)
            .ToList()
            .Where(x => x >= lenghtTree)
            .Sum();

        double unusedLogs = (dictionary
            .Where(x => x.Key.Equals(typeTree))
            .ToDictionary(x => x.Key, x => x.Value)
            .SelectMany(x => x.Value)
            .ToList()
            .Where(x => x < lenghtTree)
            .Sum() + dictionary
            .Where(x => x.Key != typeTree)
            .ToDictionary(x => x.Key, x => x.Value)
            .SelectMany(x => x.Value)
            .ToList()
            .Sum()) * average * 0.25d;

        result[0] = $"Price per meter: ${average:F2}";
        result[1] = $"Used logs price: ${usedLongs:F2}";
        result[2] = $"Unused logs price: ${unusedLogs:F2}";
        result[3] = $"CottageScraper subtotal: ${usedLongs + unusedLogs:F2}";

        return result;
    }

    private static Dictionary<string, List<int>> InsertTypesAndLenghts()
    {
        Dictionary<string, List<int>> dictionary = new Dictionary<string, List<int>>();

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("chop chop"))
            {
                break;
            }
            else
            {
                string[] tokens = readLine
                    .Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = tokens[0];
                int lenght = int.Parse(tokens[1]);

                if (!dictionary.ContainsKey(type))
                {
                    dictionary.Add(type, new List<int>());
                }

                dictionary[type].Add(lenght);
            }
        }

        return dictionary;
    }

    private static string[] ReadTypeAndMinLenghtTree()
    {
        string[] typeAndLenght = new string[2];

        for (int i = 0; i < typeAndLenght.Length; i++)
        {
            typeAndLenght[i] = Console.ReadLine();
        }

        return typeAndLenght;
    }

    private static void PrintResult(string[] result)
    {
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }
    }
}