using System;
using System.Text.RegularExpressions;
using System.Text;

class Trainegram
{
    static void Main()
    {
        string readLine;
        while ((readLine = Console.ReadLine()) != "Traincode!")
        {
            Match regex = Regex.Match(readLine, @"(^\<\[[^A-Za-z0-9]*?(?:\]\.))(.*)");
            if (!regex.Success)
            {
                continue;
            }

            regex = Regex.Match(regex.Groups[1].Value, @"(^\<\[[^A-Za-z0-9]*(?:\]\.))$");
            if (!regex.Success)
            {
                continue;
            }

            StringBuilder wagons = new StringBuilder();
            wagons.Append(regex.Groups[1].Value);

            MatchCollection regexWagons = Regex.Matches(readLine, @"(\.\[[A-Za-z0-9]*?(?:\]\.))");

            foreach (Match r in regexWagons)
            {
                regex = Regex.Match(r.Groups[1].Value, @"^(\.\[[A-Za-z0-9]*\]\.)$");

                if (regex.Success)
                {
                    wagons.Append(regex.Groups[1].Value);
                }
            }

            if (wagons.ToString().Length != readLine.Length)
            {
                continue;
            }

            Console.WriteLine(readLine);
        }
    }
}