using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class WinningTicket
{
    static void Main()
    {
        string[] tikets = Regex.Split(Console.ReadLine(), @"\s+,\s+")
            .Where(x => x.Length > 0)
            .Select(x => x.Trim())
            .ToArray();

        foreach (var tiket in tikets)
        {
            if (tiket.Length < 12 || tiket.Length > 20)
            {
                Console.WriteLine("invalid ticket");
            }
            else
            {
                string leftTiket = tiket.Substring(0, 10);
                string rightTiket = tiket.Substring(10);

                string leftSymbol = CheckMatchSymbol(leftTiket);
                string rightSymbol = CheckMatchSymbol(rightTiket);

                char[] symbols = new char[] { '@', '#', '$', '^' };

                bool hasLengthEquals = leftSymbol.Length == rightSymbol.Length;
                bool hasSymbolEquals = leftSymbol[0] == rightSymbol[0];
                bool hasContains = 
                    symbols.Contains(leftSymbol[0]) && symbols.Contains(rightSymbol[0]);
                
                if (hasLengthEquals && hasSymbolEquals && hasContains)
                {
                    if (leftSymbol.Length >= 6 && leftSymbol.Length <= 9)
                    {
                        Console.WriteLine($"tiket \"{tiket}\" - {leftSymbol.Length}" +
                            $"{leftSymbol[0]} no match");
                    }
                    else if (leftSymbol.Length == 10)
                    {
                        Console.WriteLine($"tiket \"{tiket}\" - {leftSymbol.Length}" +
                            $"{leftSymbol[0]} Jackpot!");
                    }
                } 
                
            }
        }
    }

    static string CheckMatchSymbol(string halfTiket)
    {
        int count = 1;
        string symbol = String.Empty;

        for (int i = 0; i < halfTiket.Length - 1; i++)
        {
            if (halfTiket[i] == halfTiket[i + 1])
            {
                symbol += halfTiket[i];
                count++;
                if (i == halfTiket.Length - 2)
                {
                    symbol += halfTiket[i];
                }
            }
            else if (count < 6)
            {
                symbol = String.Empty;
                count = 1;
            }
            else if (count > 6 && halfTiket.Length - count > count)
            {
                symbol = String.Empty;
                count = 1;
            }
            else if (count > 6 && halfTiket.Length - count < count)
            {
                break;
            }
        }
        return symbol;
    }
}