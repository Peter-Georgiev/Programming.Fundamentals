using System;
using System.Collections.Generic;
using System.Linq;

class BankAccount
{
    public string Name { get; set; }

    public string Bank { get; set; }

    public decimal Balance { get; set; }
}

class OptimizedBankingSystem
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
                IsertBankAccount(baseBank, readLine);
            }
        }

        PrintBankAccount(baseBank);
    }

    private static void PrintBankAccount(Dictionary<string, Dictionary<string, decimal>> baseBank)
    {
        var t = baseBank
            .OrderByDescending(bank => bank.Value.Sum(account => account.Value))
            .ThenByDescending(bank => bank.Value.Max(account => account.Value))
            //.OrderByDescending(x => x.Key.Length)
            .ToDictionary(x => x.Key, x => x.Value.OrderByDescending(a => a.Key.Length));
            



        foreach (var item in t)
        {
            var n = item.Value.OrderByDescending(x => x.Key.Length);

            foreach (var account in n)
            {
                Console.WriteLine($"{account.Key} -> {account.Value} ({item.Key})");
            }

        }

            //.ToList()
            
            //.ForEach(bank => 
            //bank.Value
            //.ToList()
            //.OrderByDescending(account => account.Key.Length)
            //.ToList()
            //.ForEach(account => Console.WriteLine($"{account.Key} -> {account.Value} ({bank.Key})")));


        Console.WriteLine();
    }

    private static void IsertBankAccount(Dictionary<string, Dictionary<string, decimal>> baseBank, string readLine)
    {
        BankAccount readBankAccount = ReadBankAccount(readLine);

        if (!baseBank.ContainsKey(readBankAccount.Bank))
        {
            baseBank
                .Add(readBankAccount.Bank, new Dictionary<string, decimal>());
        }

        if (!baseBank[readBankAccount.Bank].ContainsKey(readBankAccount.Name))
        {
            baseBank[readBankAccount.Bank]
                .Add(readBankAccount.Name, 0);
        }

        baseBank[readBankAccount.Bank][readBankAccount.Name] +=
            readBankAccount.Balance;
    }

    static BankAccount ReadBankAccount(string readLine)
    {
        string[] tokens = readLine
            .Split(" |".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        return new BankAccount()
        {
            Bank = tokens[0],
            Name = tokens[1],
            Balance = decimal.Parse(tokens[2])
        };
    }
}