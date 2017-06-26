using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class RegisterUsers
{
    static void Main()
    {
        var names = new Dictionary<string, DateTime>();

        string readLine = Console.ReadLine();

        while (!readLine.ToLower().Equals("end"))
        {
            var input = readLine
                .Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            DateTime date = DateTime.ParseExact(input[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (!names.ContainsKey(input[0]))
            {
                names.Add(input[0], date);
            }

            readLine = Console.ReadLine();
        }

        var result = names
            .Reverse()            
            .OrderBy(x => x.Value)
            .Take(5)
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var print in result)
        {
            Console.WriteLine("{0}", print.Key);
        }
    }
}