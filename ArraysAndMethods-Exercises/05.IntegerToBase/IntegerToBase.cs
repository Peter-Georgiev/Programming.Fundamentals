using System;

class IntegerToBase
{
    static void Main()
    {
        long number = int.Parse(Console.ReadLine());
        int toBase = int.Parse(Console.ReadLine());

        string result = ResultIntegerToBase(number, toBase);

        Console.WriteLine(result);
    }

    static string ResultIntegerToBase(long number, int toBase)
    {
        string integerToBase = String.Empty;

        while (number > 0)
        {
            long remainder = number % toBase;
            integerToBase = remainder + integerToBase;
            number /= toBase;
        }

        return integerToBase;
    }
}