using System;
using System.Collections.Generic;
using System.Linq;

class CamelsBack
{
    static void Main()
    {
        List<int> readLine = ReadLine();
        int size = int.Parse(Console.ReadLine());

        PrintCamelBack(readLine, size);
    }

    private static List<int> ReadLine()
    {
        List<int> readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        return readLine;
    }

    private static void PrintCamelBack(List<int> readline, int size)
    {
        if (readline.Count == size)
        {
            Console.WriteLine($"already stable: {string.Join(" ", readline)}");
        }
        else
        {
            int count = 0;

            for (int i = 0; i < readline.Count; i++)
            {
                if (readline.Count > size)
                {
                    readline.RemoveAt(0);
                    readline.RemoveAt(readline.Count - 1);
                    i--;
                    count++;
                }
            }

            Console.WriteLine($"{count} rounds");
            Console.WriteLine($"remaining: {string.Join(" ", readline)}");
        }        
    }
}