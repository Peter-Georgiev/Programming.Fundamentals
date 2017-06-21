using System;
using System.Collections.Generic;

class MixedPhones
{
    static void Main()
    {
        var phohsBook = new SortedDictionary<string, long>();

        var readLine = Console.ReadLine();

        while (!readLine.ToLower().Equals("over"))
        {
            var tokens = readLine.Split(" :".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var firstElement = tokens[0];
            var secondElement = tokens[tokens.Length - 1];

            if (long.TryParse(secondElement, out long s))
            {
                phohsBook[firstElement] = s;                
            }
            else if (long.TryParse(firstElement, out long f))
            {
                phohsBook[secondElement] = f;
            }

            readLine = Console.ReadLine();
        }

        foreach (var print in phohsBook)
        {
            Console.WriteLine($"{print.Key} -> {print.Value}");
        }
    }
}