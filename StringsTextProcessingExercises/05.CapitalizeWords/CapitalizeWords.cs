using System;
using System.Collections.Generic;
using System.Linq;

class CapitalizeWords
{
    static void Main()
    {
        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("end"))
            {
                break;
            }

            List<string> sentences = new List<string>();
            
            ReadLineAndCapitalizeWords(sentences, readLine);

            Console.WriteLine(string.Join(", ", sentences));
        }
    }

    static void ReadLineAndCapitalizeWords(List<string> sentences, string readLine)
    {
        string[] tokens = readLine
            .Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        for (int i = 0; i < tokens.Length; i++)
        {
            string oldWord = tokens[i];
            string newWord = String.Empty;
            for (int ch = 0; ch < oldWord.Length; ch++)
            {
                if (Char.IsLetterOrDigit(oldWord[ch]) || oldWord[ch] == '\'')
                {
                    if (ch == 0)
                    {
                        newWord = Convert.ToString(oldWord[ch]).ToUpper();
                    }
                    else
                    {
                        newWord += Convert.ToString(oldWord[ch]).ToLower();
                    }
                }
            }

            if (!newWord.Equals(String.Empty))
            {
                sentences.Add(newWord);
            }
        }
    }
}