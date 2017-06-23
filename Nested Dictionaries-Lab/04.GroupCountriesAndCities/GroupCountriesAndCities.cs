using System;
using System.Collections.Generic;
using System.Linq;

class GroupCountriesAndCities
{
    static void Main()
    {
        var continentsData = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();

        byte countInput = byte.Parse(Console.ReadLine());

        for (int i = 0; i < countInput; i++)
        {
            var tokens = Console.ReadLine().Split(' ').ToArray();
            var continent = tokens[0];
            var contry = tokens[1];
            var city = tokens[2];

            if (!continentsData.ContainsKey(continent))
            {
                continentsData.Add(continent, new SortedDictionary<string, SortedSet<string>>());
            }

            if (!continentsData[continent].ContainsKey(contry))
            {
                continentsData[continent][contry] = new SortedSet<string>();
                continentsData[continent][contry].Add(city);
            }
            else
            {
                continentsData[continent][contry].Add(city);
            }
        }

        foreach (var printContinents in continentsData)
        {
            var countryName = printContinents.Value;

            Console.WriteLine($"{printContinents.Key}:");

            foreach (var printContry in countryName)
            {
                var cityName = printContry.Value;

                Console.Write($"{printContry.Key} -> ");

                Console.WriteLine(string.Join(", ", cityName));
            }
        }
    }
}