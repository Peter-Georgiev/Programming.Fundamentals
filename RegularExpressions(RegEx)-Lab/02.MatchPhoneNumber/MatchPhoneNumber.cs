using System;
using System.Linq;
using System.Text.RegularExpressions;

class MatchPhoneNumber
{
    static void Main()
    {
        string regex = @"(\+[359]+\s[2]\s\d{3}(\s|-)\d{4})|(\+[359]+-[2]-\d{3}-\d{4})\b";

        string phones = Console.ReadLine();

        MatchCollection phoneMatches = Regex.Matches(phones, regex);

        string[] matchedPhones = phoneMatches
            .Cast<Match>()
            .Select(a => a.Value.Trim())
            .ToArray();

        Console.WriteLine(string.Join(", ", matchedPhones));
    }
}
