using System;

class MultiplicationTable
{
    static void Main()
    {
        int theInteger = int.Parse(Console.ReadLine());

        for (int i = 1; i <= 10; i++)
        {
            int product = theInteger * i;
            Console.WriteLine($"{theInteger} X {i} = {product}");
        }
    }
}