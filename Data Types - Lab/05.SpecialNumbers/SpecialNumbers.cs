using System;

class SpecialNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            int num = i;
            int sum = 0;

            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            bool isSumNumber = (sum == 5) || (sum == 7) || (sum == 11);

            Console.WriteLine($"{i} -> {isSumNumber}");
        }
    }
}