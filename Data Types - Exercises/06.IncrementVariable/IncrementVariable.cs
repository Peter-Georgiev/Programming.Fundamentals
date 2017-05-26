using System;

class IncrementVariable
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        byte count = 0;
        int overflows = 0;

        for (int i = 0; i < n; i++)
        {
            count++;
            if (count.Equals(0))
            {
                overflows++;
            }
        }

        Console.WriteLine(count);

        if (overflows > 0)
        {
            Console.WriteLine($"Overflowed {overflows} times");
        }
    }
}