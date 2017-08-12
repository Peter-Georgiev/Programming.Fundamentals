using System;
using System.Collections.Generic;
using System.Linq;

class Spyfer
{
    static void Main()
    {
        List<int> input = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        for (int i = 0; i < input.Count; i++)
        {
            int currentIndex = input[i];

            if (i - 1 >= 0 && i + 1 < input.Count)
            {
                int sumNeighboring = input[i - 1] + input[i + 1];

                if (sumNeighboring == currentIndex)
                {
                    input.RemoveAt(i + 1);
                    input.RemoveAt(i - 1);
                    i = 0;
                }
            }
            else if (i + 1 < input.Count && currentIndex == input[i + 1])
            {
                input.RemoveAt(i + 1);
                i = 0;
            }
            else if (i - 1 >= 0 && currentIndex == input[i - 1])
            {
                input.RemoveAt(i - 1);
                i = 0;
            }
        }

        Console.WriteLine(String.Join(" ", input));
    }
}