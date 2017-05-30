using System;

class ReverseArrayOfIntegers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] integerArray = new int[n];

        for (int i = 0; i < integerArray.Length; i++)
        {
            integerArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = integerArray.Length - 1; i >= 0; i--)
        {
            Console.Write($"{integerArray[i]} ");
        }

        Console.WriteLine();
    }
}