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
            
            char charLeft = ' ';
            char charRight = ' ';

            int maxLeft = GetTicketsLeftHalf(ticket, ref charLeft);
            int maxRight = GetTicketsRighttHalf(ticket, ref charRight);
            
            bool hasNoMatch = (charLeft == ' ') || (charRight == ' ') ||
                (maxLeft == int.MinValue) || (maxRight == int.MaxValue) ||
                (maxLeft != maxRight) || (charLeft != charRight);
            if (hasNoMatch)
            {
                Console.WriteLine($"ticket \"{ticket}\" - no match");
            }
            else if (maxLeft >= 6 && maxLeft <=9 )
            {
                Console.WriteLine($"ticket \"{ticket}\" - {maxLeft}{charLeft}");
            }
            else if (maxLeft == 10)
            {
                Console.WriteLine($"ticket \"{ticket}\" - {maxLeft}{charLeft} Jackpot!");
            }
        }
    }

    private static int GetTicketsRighttHalf(string ticket, ref char charRight)
    {
        int maxRight = int.MinValue;

        for (int i = ticket.Length / 2; i < ticket.Length; i++)
        {
            if (!"@#$^".Contains(ticket[i]))
            {
                continue;
            }

            int count = 0;

            for (int j = i; j < ticket.Length; j++)
            {

                if (ticket[i] == ticket[j])
                {
                    count++;
                }

                if (count > maxRight)
                {
                    maxRight = count;
                    charRight = ticket[i];
                }
            }
        }

        if(maxRight > 0 && !ticket.Contains(new string(charRight, maxRight)))
        {
            charRight = ' ';
            return int.MinValue;
        }
        return maxRight;
    }

    private static int GetTicketsLeftHalf(string ticket, ref char charLeft)
    {
        int maxLeft = int.MinValue;

        for (int i = 0; i < ticket.Length / 2; i++)
        {
            if (!"@#$^".Contains(ticket[i]))
            {
                continue;
            }

            int count = 0;

            for (int j = i; j < ticket.Length / 2; j++)
            {

                if (ticket[i] == ticket[j])
                {
                    count++;
                }

                if (count > maxLeft)
                {
                    maxLeft = count;
                    charLeft = ticket[i];
                }
            }
        }

        if (maxLeft > 0 && !ticket.Contains(new string(charLeft, maxLeft)))
        {
            charLeft = ' ';
            return int.MinValue;
        }
        return maxLeft;
    }
}