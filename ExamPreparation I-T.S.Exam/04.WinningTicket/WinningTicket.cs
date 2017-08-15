using System;
using System.Linq;

class WinningTicket
{
    static void Main()
    {
        string[] input = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        foreach (var t in input)
        {
            string ticket = t.Trim();

            if (ticket.Length != 20)
            {
                Console.WriteLine("invalid ticket");
                continue;
            }

            string leftTiket = ticket.Substring(0, 10);
            string rightTiket = ticket.Substring(10);

            string leftSymbol = CheckMatchSymbol(leftTiket);
            string rightSymbol = CheckMatchSymbol(rightTiket);

            if (!leftSymbol.Equals(String.Empty) && !rightSymbol.Equals(String.Empty))
            {
                bool hasLengthEquals = leftSymbol.Length >= 6 && rightSymbol.Length >= 6;
                bool hasSymbolEquals = leftSymbol[0] == rightSymbol[0];
                string symbols = "@#$^";

                if (hasLengthEquals && hasSymbolEquals && symbols.Contains(leftSymbol[0]))
                {
                    int count = Math.Min(leftSymbol.Length, rightSymbol.Length);
                    if (count == 10)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - " +
                            $"{count}{leftSymbol[0]} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {count}{leftSymbol[0]}");

                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
            else
            {
                Console.WriteLine($"ticket \"{ticket}\" - no match");
            }
        }
    }
    
    private static string CheckMatchSymbol(string s)
    {
        int max = 1;
        string symbol = String.Empty;

        for (int i = 0; i < s.Length - 1; i++)
        {
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