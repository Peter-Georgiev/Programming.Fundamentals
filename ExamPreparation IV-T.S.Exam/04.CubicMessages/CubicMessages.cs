using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class CubicMessages
{
    static void Main()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        string readLine;
        while ((readLine = Console.ReadLine()) != "Over!")
        {
            int m = int.Parse(Console.ReadLine());
            Match regex = Regex.Match(readLine, $@"(^\d+)([A-Za-z]{{{m}}})([^A-Za-z]*$)");
            if (!regex.Success)
            {
                continue;
            }

            string message = regex.Groups[2].Value;
            int[] indexes = String.Concat(regex.Groups[1].Value, regex.Groups[3].Value)
                .Where(Char.IsDigit)
                .Select(x => x - '0')
                .ToArray();
            StringBuilder digit = new StringBuilder();

            foreach (var i in indexes)
            {                
                if (!(i >= 0 && i < message.Length))
                {
                    digit.Append(' ');
                    continue;
                }

                digit.Append(message[i]);
            }

            if (!data.ContainsKey(message))
            {
                data.Add(message, digit.ToString());
            }
        }

        foreach (var kvp in data)
        {
            Console.WriteLine($"{kvp.Key} == {kvp.Value}");
        }
    }
}