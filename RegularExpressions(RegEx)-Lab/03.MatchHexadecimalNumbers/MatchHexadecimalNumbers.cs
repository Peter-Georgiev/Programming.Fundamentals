using System;
using System.Linq;
using System.Text.RegularExpressions;

class MatchHexadecimalNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();

        string regex = @"\b(?:0x)?[0-9A-F]+\b";

        string[] numbers = Regex.Matches(input, regex)
            .Cast<Match>()
            .Select(n => n.Value.Trim())
            .ToArray();

        Console.WriteLine(string.Join(" ", numbers));
    }
}