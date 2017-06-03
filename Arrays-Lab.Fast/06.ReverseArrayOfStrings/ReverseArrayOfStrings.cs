using System;
using System.Linq;

class ReverseArrayOfStrings
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ').ToArray();

        Array.Reverse(input);

        foreach (var printInput in input)
        {
            Console.Write($"{printInput} ");
        }
    }
}
