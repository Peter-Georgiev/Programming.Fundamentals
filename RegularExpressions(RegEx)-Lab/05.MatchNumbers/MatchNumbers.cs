using System;
using System.Text.RegularExpressions;

class MatchNumbers
{
    static void Main()
    {
        string regex = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

        string numberString = Console.ReadLine();

        MatchCollection numbers = Regex.Matches(numberString, regex);

        foreach (Match number in numbers)
        {
            Console.Write(number.Value + " ");
        }
    }
}