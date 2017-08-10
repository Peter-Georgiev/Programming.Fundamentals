using System;
using System.Linq;

class Wormhole
{
    static void Main()
    {
        int[] worm = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int count = 0;

        for (int i = 0; i < worm.Length; i++)
        {
            if (worm[i] == 0)
            {
                count++;
                continue;
            }

            int temp = worm[i];
            worm[i] = 0;
            i = temp - 1;            
        }

        Console.WriteLine(count);
    }
}