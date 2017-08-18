using System;
using System.Collections.Generic;
using System.Linq;

class HornetAssault
{
    static void Main()
    {
        List<long> bees = Console.ReadLine()
            .Split(' ')
            .Select(long.Parse)
            .ToList();
        List<long> hornets = Console.ReadLine()
            .Split(' ')
            .Select(long.Parse)
            .ToList();

        for (int i = 0; i < bees.Count; i++)
        {
            long power = hornets.Sum();
            if (power <= bees[i] && hornets.Count > 0)
            {
                hornets.RemoveAt(0);
                bees[i] -= power;
            }
            else if (power > bees[i])
            {
                bees.RemoveAt(i);
                i--;
            }
        }

        if (bees.Sum() > 0)
        {
            Console.WriteLine(String.Join(" ", bees.Where(x => x > 0)));
        }
        else
        {
            Console.WriteLine(String.Join(" ", hornets));
        }
    }
}