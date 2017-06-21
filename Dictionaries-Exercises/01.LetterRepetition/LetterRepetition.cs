using System;
using System.Collections.Generic;

class LetterRepetition
{
    static void Main()
    {
        var readLine = Console.ReadLine();

        var result = new Dictionary<char, int>();

        foreach (var ch in readLine)
        {
            if (result.ContainsKey(ch))
            {
                result[ch]++;
            }
            else
            {
                result[ch] = 1;
            }            
        }

        foreach (var print in result)
        {
            Console.WriteLine($"{print.Key} -> {print.Value}");
        }
    }
}