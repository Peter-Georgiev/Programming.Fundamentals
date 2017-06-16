using System;
using System.Linq;

class AverageCharacterDelimiter
{
    static void Main()
    {
        string[] readLine = ReadLine();

        char averageChar = AverageChar(readLine);

        PrintResult(averageChar, readLine);
    }

    static string[] ReadLine()
    {
        string[] readLine = Console.ReadLine()
            .Split(' ')
            .ToArray();

        return readLine;
    }

    static char AverageChar(string[] readLine)
    {
        int sumChar = 0;
        byte countChar = 0;

        for (int i = 0; i < readLine.Length; i++)
        {
            string word = readLine[i];

            for (int j = 0; j < word.Length; j++)
            {
                var ch = Convert.ToChar(word[j]);
                sumChar += ch;
                countChar++;
            }            
        }

        double divide = (sumChar / countChar);
        char averageChar;

        if ((char)Math.Round(divide) >= 'a' && (char)Math.Round(divide) <= 'z')
        {
            averageChar = (char)(Math.Round(divide) - 32);
        }
        else
        {
            averageChar = (char)Math.Round(divide);
        }
        
        return averageChar;
    }

    static void PrintResult(char averageChar, string[] readLine)
    {
        Console.WriteLine(string.Join(Convert.ToString(averageChar), readLine));
    }
}