using System;

class MultiplicationTable2
{
    static void Main()
    {
        int theInteger = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        if (n > 10)
        {
            Console.WriteLine($"{theInteger} X {n} = {theInteger * n}");
        }
        else
        {
            for (int i = n; i <= 10; i++)
            {
                int product = theInteger * i;
                Console.WriteLine($"{theInteger} X {i} = {product}");
            }
        }        
    }
}