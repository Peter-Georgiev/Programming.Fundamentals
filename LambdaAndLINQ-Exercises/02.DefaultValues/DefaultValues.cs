using System;
using System.Collections.Generic;
using System.Linq;

class DefaultValues
{
    static void Main()
    {
        var dictionary = new Dictionary<string, string>();

        string readLine = String.Empty;

        while (true)
        {
            readLine = Console.ReadLine();

            if (readLine.Equals("end"))
            {
                break;
            }
            else
            {
                string[] input = readLine
                .Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                dictionary[input[0]] = input[1];
            }
        }

        readLine = Console.ReadLine();

        //--------------------Option two--------------------//
        PrintMethodOne(dictionary, readLine);

        //--------------------Option two--------------------//
        //PrintMethodTwo(dictionary, readLine);
    }

    private static void PrintMethodTwo(Dictionary<string, string> dictionary, string readLine)
    {
        var printValue = dictionary
            .Where(x => x.Value != "null")
            .OrderByDescending(x => x.Value.Length)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var printNoNull in printValue)
        {
            Console.WriteLine($"{printNoNull.Key} <-> {printNoNull.Value}");
        }

        printValue.Clear();

        printValue = dictionary
            .Where(x => x.Value.Equals("null"))
            .ToDictionary(x => x.Key, x => readLine);

        foreach (var printNull in printValue)
        {
            Console.WriteLine($"{printNull.Key} <-> {printNull.Value}");
        }
    }

    private static void PrintMethodOne(Dictionary<string, string> dictionary, string readLine)
    {
        dictionary
            .Where(x => !x.Value.Equals("null"))
            .OrderByDescending(x => x.Value.Length)
            .ToList()
            .ForEach(x => Console.WriteLine("{0} <-> {1}", x.Key, x.Value));

        dictionary
            .Where(x => x.Value.Equals("null"))
            .Select(x => x.Key + " <-> " + readLine)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}