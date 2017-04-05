using System;
class RefactorSpecialNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int digitsSum = 0;
        int countNum = 0;
        bool isSpecialSum = false;

        for (int i = 1; i <= number; i++)
        {
            countNum = i;

            while (i > 0)
            {
                digitsSum += i % 10;
                i = i / 10;
            }

            isSpecialSum = (digitsSum == 5) || (digitsSum == 7) || (digitsSum == 11);

            Console.WriteLine($"{countNum} -> {isSpecialSum}");

            digitsSum = 0;
            i = countNum;
        }
    }
}