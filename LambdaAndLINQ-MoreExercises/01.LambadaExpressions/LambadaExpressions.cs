using System;
using System.Collections.Generic;
using System.Linq;

class LambadaExpressions
{
    static void Main()
    {
        var dictionary = new Dictionary<string, string>();

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("lambada"))
            {
                PrintResult(dictionary);
                break;
            }
            else if (readLine.Equals("dance"))
            {
                GetDance(dictionary);
            }
            else
            {
                InsertSelector(dictionary, readLine);
            }
        }
    }

    private static void GetDance(Dictionary<string, string> dictionary)
    {
        var tempDic = dictionary
                            .ToDictionary(x => x.Key, x => x.Key + "." + x.Value);

        foreach (var kvpTempDic in tempDic)
        {
            dictionary[kvpTempDic.Key] = kvpTempDic.Value;
        }
    }

    private static void PrintResult(Dictionary<string, string> dictionary)
    {
        foreach (var kvp in dictionary)
        {
            Console.WriteLine("{0} => {1}", kvp.Key, kvp.Value);
        }
    }

    private static void InsertSelector(Dictionary<string, string> dictionary, string readLine)
    {
        string[] tokens = readLine
                            .Split(" =>.".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

        string selector = tokens[0];
        string selectorObject = tokens[1];
        string property = tokens[2];

        if (!dictionary.ContainsKey(selector))
        {
            dictionary.Add(selector, selectorObject + "." + property);
        } 

        dictionary[selector] = selectorObject + "." + property;
    }
}