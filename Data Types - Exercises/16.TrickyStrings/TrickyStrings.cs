using System;
using System.Collections.Generic;

class TrickyStrings
{
    static void Main()
    {
        List<string> dataPrint = new List<string>();

        string delimiter = Console.ReadLine();
        byte n = byte.Parse(Console.ReadLine());

        while (n > 0)
        {
            string inputStr = Console.ReadLine();

            if (inputStr.Equals(""))
            {
                dataPrint.Add(delimiter);
            }
            else
            {
                dataPrint.Add(inputStr);
            }

            if (n - 1 > 0)
            {
                dataPrint.Add(delimiter);
            }

            n--;
        }

        foreach (var print in dataPrint)
        {
            Console.Write(print);
        }

        Console.WriteLine();
    }
}