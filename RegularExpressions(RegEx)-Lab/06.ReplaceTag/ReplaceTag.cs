using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ReplaceTag
{
    static void Main()
    {
        List<string> result = new List<string>();

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Trim().ToLower().Equals("end"))
            {
                break;
            }
            
            string pattern = @"(<a)(.*?)(>)(.*?)(<\/a>)";

            Regex regex = new Regex(pattern);

            result.Add(regex.Replace(readLine, @"[URL$2]$4[/URL]"));
        }

        foreach (var line in result)
        {
            Console.WriteLine(line);
        }
    }
}