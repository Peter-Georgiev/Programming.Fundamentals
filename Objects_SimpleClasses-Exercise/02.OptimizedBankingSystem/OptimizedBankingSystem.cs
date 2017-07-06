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
        List<BankAccount> baseBank = new List<BankAccount>();

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

    private static void PrintBankAccount(List<BankAccount> baseBank)
    {
        baseBank
            .OrderByDescending(x => x.Balance)
            .ThenBy(x => x.Bank.Length)
            .ToList()
            .ForEach(x => Console.WriteLine($"{x.Name} -> {x.Balance} ({x.Bank})"));
    }

    private static void IsertBankAccount(List<BankAccount> baseBank, string readLine)
    {
           baseBank.Add(ReadBankAccount(readLine));
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