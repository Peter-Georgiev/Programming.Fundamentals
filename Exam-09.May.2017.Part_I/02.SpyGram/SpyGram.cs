using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

class SpyGram
{
    static void Main()
    {
        SortedDictionary<string, List<string>> messages =
            new SortedDictionary<string, List<string>>();

        string key = Console.ReadLine();

        InsertMessage(messages);

        PrintEncryptMessages(messages, key);
    }

    private static void InsertMessage(SortedDictionary<string, List<string>> messages)
    {
        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("END"))
            {
                break;
            }

            Match regex = Regex.Match(readLine,
                @"^TO: (?<recipient>[A-Z]+); MESSAGE: (?<message>.+);$");

            if (!regex.Success)
            {
                continue;
            }

            string recipient = regex.Groups["recipient"].Value;

            if (!messages.ContainsKey(recipient))
            {
                messages.Add(recipient, new List<string>());
            }

            messages[recipient].Add(readLine);
        }
    }

    private static void PrintEncryptMessages(SortedDictionary<string, List<string>> messages, string key)
    {
        foreach (var kvp in messages)
        {
            foreach (var m in kvp.Value)
            {
                StringBuilder encrypt = new StringBuilder();
                for (int i = 0; i < m.Length; i++)
                {
                    int index = i % key.Length;
                    char @char = (char)(m[i] + int.Parse(key[index].ToString()));
                    encrypt.Append(@char.ToString());
                }
                Console.WriteLine($"{encrypt}");
            }
        }
    }
}