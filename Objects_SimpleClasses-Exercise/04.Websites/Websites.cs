using System;
using System.Collections.Generic;
using System.Linq;

class Website
{
    public string Host { get; set; }

    public string Domain { get; set; }

    public List<string> Queries { get; set; }
}

class Websites
{
    static void Main()
    {
        var website = new List<Website>();

        InsertWebsite(website);

        PrintWebsite(website);
    }

    private static void PrintWebsite(List<Website> website)
    {
        foreach (var item in website)
        {
            Console.Write($"https://www.{item.Host}.{item.Domain}");

            if (!item.Queries.Count.Equals(0))
            {
                Console.Write("/query?=");

                for (int i = 0; i < item.Queries.Count; i++)
                {
                    Console.Write($"[{item.Queries[i]}]");

                    if (i < item.Queries.Count - 1)
                    {
                        Console.Write("&");
                    }
                }
            }

            Console.WriteLine();
        }
    }

    private static void InsertWebsite(List<Website> website)
    {
        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("end"))
            {
                break;
            }

            var tokens = readLine
                .Split(" |".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Take(2)
                .ToList();

            website.Add(new Website()
            {
                Host = tokens[0],
                Domain = tokens[1],
                Queries = readLine
                .Split(" |,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Skip(2)
                .ToList()
            });
        }
    }
}