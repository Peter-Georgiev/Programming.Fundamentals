using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Cards
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"(?<powerMoreThen>[\d]{2,}.*?)?(?<power>[2-9JQKA]{1})?(?<suit>[SHDC])";

        MatchCollection cardsRegex = Regex.Matches(input, pattern);
        List<string> cards = new List<string>();

        foreach (Match card in cardsRegex)
        {
            if (int.TryParse(card.Groups["powerMoreThen"].Value, out int n))
            {
                if (n.Equals(10))
                {
                    cards.Add(card.Groups["powerMoreThen"].Value +
                        card.Groups["suit"].Value);
                }
            }
            else if (card.Groups["power"].Length > 0)
            {
                cards.Add(card.Groups["power"].Value + 
                    card.Groups["suit"].Value);                
            }           
        }

        Console.WriteLine(string.Join(", ", cards));
    }
}