using System;

class IntervalOfNumbers
{
    static void Main()
    {
        sbyte a = sbyte.Parse(Console.ReadLine());
        sbyte b = sbyte.Parse(Console.ReadLine());

        for (int i = Math.Min(a, b); i <= Math.Max(a, b); i++)
        {
            Console.WriteLine(i);
        }
    }
}