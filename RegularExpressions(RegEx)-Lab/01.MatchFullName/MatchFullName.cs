using System;
using System.Text.RegularExpressions;

class MatchFullName
{
    static void Main()
    {
        string rexex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

        string names = Console.ReadLine();

        MatchCollection matchedNames = Regex.Matches(names, rexex);

        foreach (Match name in matchedNames)
        {
            Console.Write(name.Value + " ");
        }

        Console.WriteLine();
    }
}