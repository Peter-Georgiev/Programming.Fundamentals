using System;
using System.Collections.Generic;
using System.Linq;

class SplitByWordCasing
{
    static void Main()
    {
        char[] split = new char[] 
        { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' };

        List<string> inputStr = Console.ReadLine().Split(split).ToList();

        List<string> lowerCaseWords = new List<string>(inputStr.Count);
        List<string> upperCaseWord = new List<string>(inputStr.Count);
        List<string> mixedCaseWord = new List<string>(inputStr.Count);

        for (int i = 0; i < inputStr.Count; i++)
        {
            string tempword = inputStr[i];
            byte countLowerWords = 0;
            byte countUperWord = 0;
            bool isMixedWord = true;

            for (int j = 0; j < tempword.Length; j++)
            {
                if ((char)tempword[j] >= 'a' &&  (char)tempword[j] <= 'z')
                {
                    countLowerWords++;
                }
                else if ((char)tempword[j] >= 'A' && (char)tempword[j] <= 'Z')
                {
                    countUperWord++;
                }
            }

            bool isWordEmpty = tempword == string.Empty;
            if (countLowerWords - tempword.Length == 0 && !isWordEmpty)
            {
                lowerCaseWords.Add(tempword);
                isMixedWord = false;
            }
            else if (countUperWord - tempword.Length == 0 && !isWordEmpty)
            {
                upperCaseWord.Add(tempword);
                isMixedWord = false;
            }
            else if (isMixedWord && !isWordEmpty)
            {
                mixedCaseWord.Add(tempword);
            }
        }

        Console.WriteLine($"Lower-case: {string.Join(", ", lowerCaseWords)}");
        Console.WriteLine($"Mixed-case: {string.Join(", ", mixedCaseWord)}");
        Console.WriteLine($"Upper-case: {string.Join(", ", upperCaseWord)}");
    }
}