using System;

class WaterOverflow
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());

        int capacity = 255;
        int capacityLeft = capacity;

        for (short i = 0; i < n; i++)
        {
            int litersToPour = int.Parse(Console.ReadLine());

            if (capacityLeft - litersToPour >= 0)
            {
                capacityLeft -= litersToPour;
            }
            else
            {
                Console.WriteLine("Insufficient capacity!");
            }
        }

        Console.WriteLine(capacity - capacityLeft);
    }
}