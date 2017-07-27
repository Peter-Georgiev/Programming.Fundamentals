using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Demon
{
    public string Name { get; set; }
    public int Health { get; set; }
    public double Damage { get; set; }
}

class NetherRealms
{
    static void Main()
    {
        List<Demon> demons = new List<Demon>();

        string[] tokens = Regex.Split(Console.ReadLine(), @",\s+")
            .Select(x => x.Trim())
            .ToArray();

        for (int i = 0; i < tokens.Length; i++)
        {
            MatchCollection regex = Regex.Matches(tokens[i], @"(?<number>-\d.\d|\d.\d|\d)|(?<characters>[^*+-\/])|(?<arithmetic>.)");

            int healt = 0;
            double damage = 0.00d;
            List<char> arithmetic = new List<char>();

            foreach (Match item in regex)
            {
                if (item.Groups["characters"].Value != String.Empty)
                {
                    healt += char.Parse(item.Groups["characters"].Value);
                }

                if (double.TryParse(item.Groups["number"].Value, out double d))
                {
                    damage += d;
                }
                else if (int.TryParse(item.Groups["number"].Value, out int n))
                {
                    damage += n;
                }


                if (item.Groups["arithmetic"].Value != String.Empty)
                {
                    char[] ch = new char[] { '*', '+', '-', '/' };
                    if (ch.Contains(char.Parse(item.Groups["arithmetic"].Value)))
                    {
                        arithmetic.Add(char.Parse(item.Groups["arithmetic"].Value));
                    }
                }
            }

            foreach (var calc in arithmetic)
            {
                switch (calc)
                {
                    case '*':
                        damage *= 2.00;
                        break;
                    case '/':
                        damage /= 2.00;
                        break;
                }
            }

            Demon newDemon = new Demon
            {
                Name = tokens[i],
                Health = healt,
                Damage = damage
            };

            demons.Add(newDemon);
        }

        PrintResult(demons);
    }

    private static void PrintResult(List<Demon> demons)
    {
        List<Demon> result = demons
                    .OrderBy(x => x.Name)
                    .ToList();
        foreach (var d in result)
        {
            Console.WriteLine($"{d.Name} - {d.Health} health, {d.Damage:F2} damage");
        }
    }
}