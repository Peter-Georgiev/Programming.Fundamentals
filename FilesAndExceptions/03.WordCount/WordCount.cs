using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class WordCount
{
    static void Main()
    {
        string[] wordsLine = File.ReadAllText("words.txt")
            .ToLower()
            .Split(" ,.:;!?-\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        string[] inputsLine = File.ReadAllText("Input.txt")
            .ToLower()
            .Split(" ,.:;!?-\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);


        var wordcount = new Dictionary<string, int>();

        foreach (var item in wordsLine)
        {
            if (!wordcount.ContainsKey(item))
            {
                wordcount.Add(item, 0);
            }
        }

        foreach (var item in inputsLine)
        {
            if (wordcount.ContainsKey(item))
            {
                wordcount[item]++;
            }
        }

        wordcount
            .OrderByDescending(x => x.Value).ToList()
            .ForEach(kvp => File.AppendAllText("Output.txt", $"{kvp.Key} - {kvp.Value}" + Environment.NewLine));
    }
}