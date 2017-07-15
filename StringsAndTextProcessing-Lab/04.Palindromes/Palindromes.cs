using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Palindromes
{
    static void Main()
    {
        string text = Console.ReadLine();
        StringBuilder word = new StringBuilder();
        SortedSet<string> palindromes = new SortedSet<string>();

        // solving the problem
        for (int i = 0; i < text.Length; i++)
        {
            // instead of trimming every character that is not a letter I am using stringBuilder to save the words until the check for palindrom.
            while (char.IsLetter(text[i]))
            {
                word.Append(text[i]);
                i++; // It misses one character at the end after the while is over but it is not a letter character so I don't need it 
                if (i >= text.Length)
                {
                    break;
                }
            }

            if (word.ToString() == Reverse(word) && word.ToString() != string.Empty)
            {
                palindromes.Add(word.ToString()); // I use to string method in order to save the word in the SortedSet. The StringBuilder is muttable even when I save it in the set when word is cleared downwards it is also cleared in the set. 
            }
            word.Clear(); // reversing to empty StringBuilder

        }

        // Print Result
        Console.WriteLine(string.Join(", ", palindromes));
    }

    static string Reverse(StringBuilder word)
    {
        StringBuilder reversedWord = new StringBuilder();
        for (int j = word.Length - 1; j >= 0; j--)
        {
            reversedWord.Append(word[j]);
        }
        return reversedWord.ToString();
    }
}