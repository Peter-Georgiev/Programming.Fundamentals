using System;

class NumberChecker
{
    static void Main()
    {
        try
        {
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine("integer");
        }
        catch (Exception)
        {
            Console.WriteLine("floating-point");
        }
    }
}