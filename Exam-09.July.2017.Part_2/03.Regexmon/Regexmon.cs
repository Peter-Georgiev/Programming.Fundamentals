using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Regexmon
{
    static void Main()
    {
        List<string> didimons = new List<string>();
        List<string> bojomons = new List<string>();

        string readLine = Console.ReadLine();

        InsertDidimonAndBojomon(didimons, bojomons, readLine);

        PrintResult(didimons, bojomons);
    }

    static void InsertDidimonAndBojomon(List<string> didimons, List<string> bojomons, string readLine)
    {
        bool hasDidimon = true;
        bool hasBojomon = true;

        while (true)
        {
            string pattern = @"(?<didimon>[^A-Za-z-]*)";
            MatchCollection regex = Regex.Matches(readLine, pattern);  

            foreach (Match r in regex)
            {
                string didimon = r.Groups["didimon"].Value;
                if (didimon.Length > 0 && r.Success)
                {
                    didimons.Add(didimon);
                    pattern = $@"(.*?{Regex.Escape(didimon)})?(.*)";
                    readLine = Regex.Replace(readLine, pattern, @"$2");
                    hasDidimon = false;
                    break;
                }
            }

            if (hasDidimon)
            {
                break;
            }

            pattern = @"(?<bojomon>[A-Za-z]+-[A-Za-z]+)";
            regex = Regex.Matches(readLine, pattern);

            foreach (Match r in regex)
            {
                string bojomon = r.Groups["bojomon"].Value;
                if (bojomon.Length > 0 && r.Success)
                {
                    bojomons.Add(bojomon);
                    pattern = $@"(.*?{Regex.Escape(bojomon)})?(.*)";
                    readLine = Regex.Replace(readLine, pattern, @"$2");
                    hasBojomon = false;
                    break;
                }
            }

            if (hasBojomon)
            {
                break;
            }

            hasDidimon = true;
            hasBojomon = true;
        }
    }

    static void PrintResult(List<string> didimons, List<string> bojomons)
    {
        for (int i = 0; i < Math.Max(didimons.Count, bojomons.Count); i++)
        {
            if (i < didimons.Count)
            {
                Console.WriteLine(didimons[i]);
            }

            if (i < bojomons.Count)
            {
                Console.WriteLine(bojomons[i]);
            }
        }
    }
}