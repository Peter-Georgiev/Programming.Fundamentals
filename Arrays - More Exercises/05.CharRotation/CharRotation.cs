using System;
using System.Linq;

class CharRotation
{
    static void Main()
    {
        string line = Console.ReadLine();        
        int[] elementInteger = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        char[] elementChar = line.ToCharArray();

        for (int i = 0; i < elementInteger.Length; i++)
        {
            if (elementInteger[i] % 2 == 0)
            {
                Math.Abs(elementInteger[i] = elementChar[i] - elementInteger[i]);
            }
            else
            {
                Math.Abs(elementInteger[i] = elementChar[i] + elementInteger[i]);
            }
        }

        foreach (var print in elementInteger)
        {
            Console.Write((char)(print));
        }

        Console.WriteLine();
    }
}