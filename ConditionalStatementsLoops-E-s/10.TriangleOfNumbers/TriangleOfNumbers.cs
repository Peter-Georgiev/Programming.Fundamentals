using System;

class TriangleOfNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int count = 0;
        for (int i = 1; i <= n; i++)
        {
            count++;
            for (int j = 0; j < i; j++)
            {
                Console.Write(count + " ");
            }
            Console.WriteLine();
        }
    }
}