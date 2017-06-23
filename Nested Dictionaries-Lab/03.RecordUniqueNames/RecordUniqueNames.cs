using System;
using System.Collections.Generic;

class RecordUniqueNames
{
    static void Main()
    {
        HashSet<string> set = new HashSet<string>();

        byte count = byte.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            var readLine = Console.ReadLine();

            set.Add(readLine);
        }

        Console.WriteLine(string.Join(Environment.NewLine, set));
    }
}