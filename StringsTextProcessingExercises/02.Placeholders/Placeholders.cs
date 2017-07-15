using System;
using System.Collections.Generic;
using System.Linq;

class Placeholders
{
    static void Main()
    {
        List<string> result = new List<string>();

        ReadAndReplaceText(result);

        PrintResult(result);
    }

    private static void PrintResult(List<string> result)
    {
        foreach (var print in result)
        {
            Console.WriteLine(print);
        }
    }

    private static void ReadAndReplaceText(List<string> result)
    {
        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("end"))
            {
                break;
            }

            string[] tokens = readLine
                .Split(new string[] { " -> " },
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] tokensElements = tokens[1]
                .Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string sentence = tokens[0];

            for (int i = 0; i < tokensElements.Length; i++)
            {
                string newWord = tokensElements[i].Trim();
                string oldWord = "{" + i + "}";
                sentence = sentence.Replace(oldWord, newWord);
            }

            result.Add(sentence);
        }
    }
}