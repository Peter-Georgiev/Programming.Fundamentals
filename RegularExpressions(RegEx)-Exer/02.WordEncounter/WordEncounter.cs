using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class WordEncounter
{
    static void Main()
    {
        List<string> result = new List<string>();
        string filterStr = Console.ReadLine();

        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("end"))
            {
                break;
            }

            string pattern = @"^[A-Z].*[.!?]$";
            Match regexSentence = Regex.Match(readLine, pattern);

            pattern = @"\b\w+\b";
            string sentence = regexSentence.Value;
            MatchCollection regexWord = Regex.Matches(sentence, pattern);

            char letter = char.Parse(filterStr.Substring(0, 1));
            int countLetter = int.Parse(filterStr.Substring(1, 1));

            foreach (Match word in regexWord)
            {
                char[] findLetter = word.Value
                    .ToCharArray()
                    .Where(l => l.Equals(letter))
                    .ToArray();

                if (findLetter.Length >= countLetter)
                {
                    result.Add(word.Value);
                }
            }
        }

        PrintResult(result);
    }

    static void PrintResult(List<string> result)
    {
        Console.WriteLine(String.Join(", ", result));
    }
}