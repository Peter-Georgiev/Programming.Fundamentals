using System;
using System.Linq;

class ArrayElementsEqualToTheirIndex
{
    static void Main()
    {
        int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        for (int i = 0; i < arrayOfIntegers.Length; i++)
        {
            if (i == arrayOfIntegers[i])
            {
                Console.Write(i + " ");
            }
        }

        Console.WriteLine();
    }
}