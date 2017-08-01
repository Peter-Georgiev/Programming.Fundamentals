using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class RageQuit
{
    static void Main()
    {
        string readLine = Console.ReadLine().ToUpper();

        MatchCollection regex =
            Regex.Matches(readLine, @"(?<word>.+?)((?<number>\d\d?))");

        StringBuilder result = new StringBuilder();

        foreach (Match l in regex)
        {
            for (int i = 0; i < int.Parse(l.Groups["number"].Value); i++)
            {
                result.Append($"{l.Groups["word"].Value}");
            }
        }

        int uniqueSymbol = result
            .ToString()
            .Distinct()
            .Count();

        Console.WriteLine($"Unique symbols used: {uniqueSymbol}");
        Console.WriteLine(result);
    }
}