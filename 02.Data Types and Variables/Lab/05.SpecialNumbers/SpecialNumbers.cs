using System;

class SpecialNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int sum;
        for (int i = 1; i <= n; i++)
        {
            sum = i % 10;
            sum = sum / 10;
            Console.WriteLine($"{i} -> {sum}");

        }
    }
}