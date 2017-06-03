using System;

class SieveOfEratosthens
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        bool[] primes = new bool[n + 1];

        for (int i = 0; i <= n; i++)
        {
            primes[i] = true;
        }

        primes[0] = primes[1] = false;

        for (int p = 2; p <= n; p++)
        {
            if (primes[p] == true)
            {
                Console.Write($"{p} ");

                for (int j = 2; j <= n; j++)
                {
                    if (0 <= j * p && j * p <= n)
                    {
                        primes[j * p] = false;
                    }
                }
            }
        }

        Console.WriteLine();
    }
}