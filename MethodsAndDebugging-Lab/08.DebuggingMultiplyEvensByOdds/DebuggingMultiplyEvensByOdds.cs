using System;

class DebuggingMultiplyEvensByOdds
{
    static void Main()
    {
        int digit = int.Parse(Console.ReadLine());

        int multipleSum = GetMultipleOfEvensAndOdds(Math.Abs(digit));

        Console.WriteLine(multipleSum);
    }

    private static int GetMultipleOfEvensAndOdds(int n)
    {
        int sumEvens = GetSumOfEvenDigits(n);
        int sumOdds = GetSumOfOddDigits(n);
        return sumEvens * sumOdds;
    }

    private static int GetSumOfOddDigits(int n)
    {
        int sum = 0;
        while (n > 0)
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

    private static int GetSumOfEvenDigits(int n)
    {
        int sum = 0;
        while (n > 0)
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
}