using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PokemonDontGo
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());

        int originalN = n;

        int count = 0;
        while (n > m)
        {
            n -= m;
            count++;
        }
        
        decimal percentM = ((long)m * (long)originalN) / 100m;
        decimal percentN = ((long)originalN * (long)m) / 100m;

        if (n < m)
        {
            Console.WriteLine(n);
            Console.WriteLine(count);
        }
        else if (n == m)
        {
            if (n >= y && n != 0 && y != 0)
            {
                int division = n / y;
                Console.WriteLine(division);
            }
            else
            {
                while (n >= m)
                {
                    n -= m;
                }
                Console.WriteLine(n);
            }
            Console.WriteLine(count);
        }
    }
}