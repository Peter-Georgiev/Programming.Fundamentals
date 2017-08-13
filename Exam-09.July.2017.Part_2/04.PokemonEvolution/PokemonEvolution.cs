using System;
using System.Collections.Generic;
using System.Linq;

class Pokemons
{
    public string Type { get; set; }

    public int Index { get; set; }
}

class PokemonEvolution
{
    static void Main()
    {
        Dictionary<string, List<Pokemons>> pokemons =
            new Dictionary<string, List<Pokemons>>();

        while (true)
        {
            string[] tokens = Console.ReadLine()
            .Split(new string[] { " -> " },
            StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            if (tokens[0].Equals("wubbalubbadubdub"))
            {
                break;
            }
            else if (tokens.Length == 3)
            {
                InsertPokemon(pokemons, tokens);
            }
            else if (pokemons.ContainsKey(tokens[0]))
            {
                GetPokemonName(pokemons, tokens[0]);
            }
        }

        PrintResult(pokemons);
    }

    static void InsertPokemon(Dictionary<string, List<Pokemons>> pokemons, string[] tokens)
    {
        string name = tokens[0];
        string type = tokens[1];
        int index = int.Parse(tokens[2]);

        if (!pokemons.ContainsKey(name))
        {
            pokemons.Add(name, new List<Pokemons>());
        }

        Pokemons newPokemon = new Pokemons()
        {
            Type = type,
            Index = index
        };

        pokemons[name].Add(newPokemon);
    }

    static void GetPokemonName(Dictionary<string, List<Pokemons>> pokemons, string name)
    {
        foreach (var kvp in pokemons.Where(x => x.Key == name))
        {
            Console.WriteLine("# " + kvp.Key);

            foreach (var e in kvp.Value)
            {
                Console.WriteLine(e.Type + " <-> " + e.Index);
            }
        }
    }

    static void PrintResult(Dictionary<string, List<Pokemons>> pokemons)
    {
        foreach (var kvp in pokemons)
        {
            Console.WriteLine("# " + kvp.Key);

            foreach (var e in kvp.Value.OrderByDescending(x => x.Index))
            {
                Console.WriteLine(e.Type + " <-> " + e.Index);
            }
        }
    }
}