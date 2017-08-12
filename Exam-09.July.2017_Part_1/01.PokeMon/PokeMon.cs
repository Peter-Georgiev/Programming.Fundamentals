using System;

class PokeMon
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());

        decimal percentM = n * 0.5m;

        int count = 0;
        while (n >= m)
        {
            n -= m;
            count++;

            if (n == percentM && y > 0)
            {
                n /= y;
            }
        }

        Console.WriteLine(n);
        Console.WriteLine(count);
    }
}