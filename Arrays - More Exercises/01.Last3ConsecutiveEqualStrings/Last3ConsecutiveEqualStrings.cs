using System;
using System.Linq;

class Last3ConsecutiveEqualStrings
{
    static void Main()
    {
        string[] array = Console.ReadLine().Split(' ').ToArray();

        byte count = 0;

        for (int i = array.Length - 1; i > 0; i--)
        {
            if (array[i] == array[i - 1])
            {
                count++;
                if (count == 2)
                {
                    Console.WriteLine($"{array[i + 1]} {array[i]} {array[i - 1]}");
                    break;
                }
            }
            else
            {
                count = 0;
            }
        }        
    }
}