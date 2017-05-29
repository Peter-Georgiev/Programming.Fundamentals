using System;

class DebuggingAndProgramFlow
{
    static void Main()
    {
        int digit = int.Parse(Console.ReadLine());
        int result = GetMultipleOfEvensAndOdds(digit);
        Console.WriteLine(result);
    }

    public static int GetSumOfOddDigits(int n)
    {
        int sum = 0;
        while (Math.Abs(n) > 0)
        {
            int lastDigit = n % 10;
            if (lastDigit % 2 != 0)
            {
                sum += lastDigit;
            }
            n /= 10;
        }
        return sum;
    }

    public static int GetSumEvenDigits(int n)
    {
        int sum = 0;
        while (Math.Abs(n) > 0)
        {
            int lastDigit = n % 10;
            if (lastDigit % 2 == 0)
            {
                sum += lastDigit;
            }
            n /= 10;
        }
        return sum;
    }

    public static int GetMultipleOfEvensAndOdds(int n)
    {
        int sumEvens = GetSumEvenDigits(n);
        int sumOdd = GetSumOfOddDigits(n);
        return sumEvens * sumOdd;
    }
}
