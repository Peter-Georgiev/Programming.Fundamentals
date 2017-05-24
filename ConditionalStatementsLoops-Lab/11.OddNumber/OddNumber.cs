using System;

class OddNumber
{
    static void Main()
    {
        int number = Math.Abs(int.Parse(Console.ReadLine()));

        bool isOddNum = number % 2 == 0;
        while (isOddNum)
        {
            Console.WriteLine("Please write an odd number.");
            number = Math.Abs(int.Parse(Console.ReadLine()));
            isOddNum = number % 2 == 0;
        }

        Console.WriteLine($"The number is: {number}");
    }
}