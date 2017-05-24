using System;

class RefactorSpecialNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int sum = 0;
        int count = 0;
        bool isSpecial = false;

        for (int i = 1; i <= number; i++)
        {
            count = i;
            while (i > 0)
            {
                sum += i % 10;
                i = i / 10;
            }

            isSpecial = (sum == 5) || (sum == 7) || (sum == 11);

            Console.WriteLine($"{count} -> {isSpecial}");

            sum = 0;
            i = count;
        }
    }
}