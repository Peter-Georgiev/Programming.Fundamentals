using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Demon
{
    public double Health { get; set; }

    public double Damage { get; set; }
}

class NetherRealms
{
    static void Main()
    {
        SortedDictionary<string, Demon> data = new SortedDictionary<string, Demon>();        

        InsertDemon(data);

        PrintResult(data);
    }

    private static void InsertDemon(SortedDictionary<string, Demon> data)
    {
        string[] tokens = ReadLine();

        foreach (var t in tokens)
        {
            int health = 0;
            double damage = 0d;
            MatchCollection regex =
                Regex.Matches(t, @"(?<number>-?\d+(?:\.\d+)?)|(?<characters>[^*+-\/\.])|(?<arithmetic>[*\/])");

            foreach (Match r in regex)
            {
                if (r.Groups["characters"].Value.Trim() != String.Empty)
                {
                    health += char.Parse(r.Groups["characters"].Value.Trim());
                }

                if (r.Groups["number"].Value != String.Empty)
                {
                    damage += double.Parse(r.Groups["number"].Value);
                }
            }

            foreach (Match r in regex)
            {
                if (r.Groups["arithmetic"].Value != String.Empty)
                {
                    if ("*/".Contains(char.Parse(r.Groups["arithmetic"].Value)))
                    {
                        if (char.Parse(r.Groups["arithmetic"].Value) == '*')
                        {
                            damage *= 2;
                        }
                        else if (char.Parse(r.Groups["arithmetic"].Value) == '/')
                        {
                            damage /= 2;
                        }
                    }
                }
            }

            data[t] = new Demon()
            {
                Health = health,
                Damage = damage
            };
        }
    }

    private static void PrintResult(SortedDictionary<string, Demon> data)
    {
        foreach (var kvp in data)
        {
            Console.WriteLine($"{kvp.Key} - " +
                $"{kvp.Value.Health} health, {kvp.Value.Damage:F2} damage");
        }
    }

    private static string[] ReadLine()
    {
        string readLine = Console.ReadLine();

        string[] tokens = Regex.Split(readLine, @",\s*")
            .Where(x => x.Length > 0)
            .Select(x => x.Trim())
            .ToArray();
        return tokens;
    }
}