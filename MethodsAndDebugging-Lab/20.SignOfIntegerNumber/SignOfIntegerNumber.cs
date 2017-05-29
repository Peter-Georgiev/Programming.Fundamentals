using System;

class SignOfIntegerNumber
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        PrintSing(number);
    }

    public static void PrintSing(int number)
    {
        if (number > 0)
        {
            Console.WriteLine($"The number {number} is positive.");
        }
        else if (number < 0)
        {
            Console.WriteLine($"The number {number} is negative.");
        }
        else
        {
            Console.WriteLine($"The number {number} is zero.");
        }
    }
}