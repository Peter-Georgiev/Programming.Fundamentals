using System;
using System.Collections.Generic;
using System.Linq;

class OrderedBankingSystem
{
    static void Main()
    {
        var baseBank = new Dictionary<string, Dictionary<string, decimal>>();

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("end"))
            {
                break;
            }
            else
            {
                InsertBaseBank(baseBank, readLine);
            }
        }

        PrintResult(baseBank);        
    }

    private static void PrintResult(Dictionary<string, Dictionary<string, decimal>> baseBank)
    {
        baseBank
            .OrderByDescending(bank => bank.Value.Sum(account => account.Value))
            .ThenByDescending(bank => bank.Value.Max(account => account.Value))
            .ToList()
            .ForEach(bank => bank.Value.OrderByDescending(account => account.Value)
            .ToList()
            .ForEach(account => Console.WriteLine($"{account.Key} -> {account.Value} ({bank.Key})")));
    }

    private static void InsertBaseBank(Dictionary<string, Dictionary<string, decimal>> baseBank, string readLine)
    {
        string[] tokens = readLine
            .Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        string bank = tokens[0];
        string account = tokens[1];
        decimal balance = decimal.Parse(tokens[2]);

        if (!baseBank.ContainsKey(bank))
        {
            baseBank.Add(bank, new Dictionary<string, decimal>());            
        }

        if (!baseBank[bank].ContainsKey(account))
        {
            baseBank[bank].Add(account, 0);
        }

        baseBank[bank][account] += balance;
    }
}