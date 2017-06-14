using System;
using System.Collections.Generic;

class StringEncryption
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());

        string result = String.Empty;

        for (int i = 0; i < n; i++)
        {
            char letter = char.Parse(Console.ReadLine());
            result += Encrypt(letter);
        }

        PrintResult(result);
    }

    private static void PrintResult(string result)
    {        
        Console.WriteLine(result);
    }

    static string Encrypt(char letter)
    {
        List<int> digitLetter = new List<int>();
        int digit = letter;

        while (digit > 0)
        {
            digitLetter.Add(digit % 10);
            digit /= 10;
        }

        int lastDigit = digitLetter[0];
        int firstDigit = digitLetter[digitLetter.Count - 1];

        int firstLetter = letter + lastDigit;
        int lastLetter = letter - firstDigit;        

        string encrypt = Convert.ToString((char)firstLetter);
        encrypt += $"{firstDigit}{lastDigit}";
        encrypt += Convert.ToString((char)lastLetter);

        return encrypt;
    }
}