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
            StringBuilder wagons = new StringBuilder();
            Match regex = Regex.Match(readLine,
                @"(^<\[[^A-Za-z0-9]*?\]\.)(\.\[[A-Za-z0-9]*?\]\.)*?$");
            if (!regex.Success)
            {
                continue;
            }

            regex = Regex.Match(readLine, @"(^\<\[[^A-Za-z0-9]*?(?:\]\.))(.*)");
            if (!regex.Success)
            {
                continue;
            }
            wagons.Append(regex.Groups[1].Value);

            regex = Regex.Match(regex.Groups[1].Value, @"(^\<\[[^A-Za-z0-9]*(?:\]\.))$");
            if (!regex.Success)
            {
                continue;
            }
                       

            Console.WriteLine(readLine);
        }
    }
}