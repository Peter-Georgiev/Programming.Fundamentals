using System;
using System.Linq;
using System.Text.RegularExpressions;

class WinningTicket
{
    static void Main()
    {
        string[] tikets = Regex.Split(Console.ReadLine(), @",\s+")
            .Where(x => x.Length > 0)
            .Select(x => x.Trim())
            .ToArray();

        foreach (var tiket in tikets)
        {
            if (tiket.Length != 20)
            {
                Console.WriteLine("invalid ticket");
            }
            else
            {
                string leftTiket = tiket.Substring(0, 10);
                string rightTiket = tiket.Substring(10);

                string leftSymbol = CheckMatchSymbol(leftTiket);
                string rightSymbol = CheckMatchSymbol(rightTiket);
                
                if (!leftSymbol.Equals(String.Empty) && !rightSymbol.Equals(String.Empty))
                {
                    bool hasLengthEquals = leftSymbol.Length >= 6 && rightSymbol.Length >= 6;
                    bool hasSymbolEquals = leftSymbol[0]  == rightSymbol[0];
                    string symbols = "@#$^";

                    if (hasLengthEquals && hasSymbolEquals && symbols.Contains(leftSymbol[0]))
                    {
                        int count = Math.Min(leftSymbol.Length, rightSymbol.Length);
                        if (count == 10)
                        {
                            Console.WriteLine($"ticket \"{tiket}\" - " +
                                $"{count}{leftSymbol[0]} Jackpot!");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{tiket}\" - {count}{leftSymbol[0]}");

                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{tiket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{tiket}\" - no match");
                }                
            }
        }
    }

    static string CheckMatchSymbol(string s)
    {
        int max = 1;
        string symbol = String.Empty;

        for (int i = 0; i < s.Length - 1; i++)
        {
            char ch = s[i];
            int count = 1;
            while (i + count < s.Length && s[i + count] == s[i])
            {
                count++;
                if (count > max)
                {
                    max = count;
                    symbol = s.Substring(i, count);
                }
            }
        }

        return symbol;
    }
}