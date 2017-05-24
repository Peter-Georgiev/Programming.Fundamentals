using System;

class SumOfOddNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int sum = 0;
        int count = 0;
        for (int i = 1; i < 100; i += 2)
        {
            count++;
            if (count <= number)
            {
                sum += i;
                Console.WriteLine(i);
            }
            else
            {
                break;
            }

        }
        Console.WriteLine($"Sum: {sum}");
    }
}