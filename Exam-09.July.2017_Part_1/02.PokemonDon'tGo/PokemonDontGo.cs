using System;
using System.Collections.Generic;
using System.Linq;

class PokemonDontGo
{
    static void Main()
    {
        long result = 0;

        List<long> input = Console.ReadLine()
            .Split(' ')
            .Select(long.Parse)
            .ToList();

        while (input.Count > 0)
        {
            int command = int.Parse(Console.ReadLine());
            
            if (command < 0)
            {
                long index = input[0];
                input[0] = input[input.Count - 1];

                GetIncreaseDecrease(input, index);
                result += index;
            }
            else if (command > input.Count - 1)
            {
                long index = input[input.Count - 1];
                input[input.Count - 1] = input[0];

                GetIncreaseDecrease(input, index);
                result += index;
            }
            else if (command < input.Count)
            {
                long index = input[command];
                input.RemoveAt(command);

                GetIncreaseDecrease(input, index);
                result += index;
            }
        }

        Console.WriteLine(result);
    }

    static void GetIncreaseDecrease(List<long> input, long index)
    {
        for (int i = 0; i < input.Count; i++)
        {
            if (index >= input[i])
            {
                input[i] += index;
            }
            else
            {
                input[i] -= index;
            }
        }
    }
}