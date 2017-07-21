using System;
using System.Linq;
using System.Text.RegularExpressions;

class MatchPhoneNumber
{
    static void Main()
    {
        //string regex = @"";
        string text = "12.02.2017";

        string pattern = @"([0-9]{2})";

        //Regex regex = new Regex(pattern);

        bool isr = Regex.IsMatch(text, pattern);
        Console.WriteLine();
    }
}
