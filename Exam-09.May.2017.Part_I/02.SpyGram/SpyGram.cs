using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

class SpyGram
{
    static void Main()
    {
        SortedDictionary<string, List<string>> data = new SortedDictionary<string, List<string>>();
        
        int[] key = Console.ReadLine()
            .Select(x => x - '0')
            .ToArray();

        InsertMessage(data, key);

        PrintResult(data);
    }

    private static void PrintResult(SortedDictionary<string, List<string>> data)
    {
        foreach (var kvp in data)
        {
            foreach (var m in kvp.Value)
            {
                Console.WriteLine(m);
            }
        }
    }

    private static void InsertMessage(SortedDictionary<string, List<string>> data, int[] key)
    {
        string readLine;
        while ((readLine = Console.ReadLine()) != "END")
        {
            Match regex = Regex.Match(readLine, @"TO: ([A-Z]+); MESSAGE: (.+);");
            if (!regex.Success)
            {
                continue;
            }

            string recipient = regex.Groups[1].Value;
            string message = regex.Groups[2].Value;

            if (!data.ContainsKey(recipient))
            {
                data.Add(recipient, new List<string>());
            }

            StringBuilder newMessage = new StringBuilder();

            for (int i = 0; i < readLine.Length; i++)
            {
                int index = i % key.Length;
                newMessage.Append((char)(readLine[i] + key[index]));
            }

            data[recipient].Add(newMessage.ToString());
        }
    }
}