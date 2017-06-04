using System;
using System.Linq;

class Phonebook
{
    static void Main()
    {
        string[] phoneNumbers = Console.ReadLine().Split(' ').ToArray();
        string[] phoneNames = Console.ReadLine().Split(' ').ToArray();
        string lines = Console.ReadLine();

        while (!lines.Equals("done"))
        {
            for (int i = 0; i < phoneNames.Length; i++)
            {
                if (lines == phoneNames[i])
                {
                    Console.WriteLine($"{phoneNames[i]} -> {phoneNumbers[i]}");
                }
            }

            lines = Console.ReadLine();
        }
    }
}