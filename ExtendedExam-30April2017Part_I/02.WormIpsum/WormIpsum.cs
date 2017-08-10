using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WormIpsum
{
    static void Main()
    {
        List<string> result = new List<string>();

        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("Worm Ipsum"))
            {
                break;
            }

            Match regex = Regex.Match(readLine, @"(^[A-Z].*?[\.])");

            if (!regex.Success || regex.Groups[1].Value.Length != readLine.Length)
            {
                continue;
            }

            MatchCollection regexWord = Regex.Matches(readLine, @"\b\w+\b");
            StringBuilder newSentence = new StringBuilder(readLine);
            foreach (var w in regexWord)
            {
                char[] @char = w.ToString().ToCharArray();
                char ch = ' ';
                int max = int.MinValue;

                for (int i = 0; i < @char.Length; i++)
                {
                    int count = 0;

                    for (int j = i; j < @char.Length; j++)
                    {
                        if (@char[i] == @char[j])
                        {
                            count++;
                        }

                        if (count > max)
                        {
                            ch = @char[i];
                            max = count;
                        }
                    }
                }

                if (max == 1)
                {
                    continue;
                }

                for (int i = 0; i < @char.Length; i++)
                {
                    @char[i] = ch;
                }

                string newWord = String.Concat(@char);
                newSentence = newSentence.Replace(w.ToString(), newWord);

            }
            result.Add(newSentence.ToString());
        }

        foreach (var r in result)
        {
            Console.WriteLine(r);
        }
    }
}