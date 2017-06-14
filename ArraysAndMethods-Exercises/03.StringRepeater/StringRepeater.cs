using System;
using System.Collections.Generic;

class StringRepeater
{
    static void Main()
    {
        string readLine = Console.ReadLine();
        byte count = byte.Parse(Console.ReadLine());

        List<string> repearString = RepearString(readLine, count);

        PrintRepearString(repearString);
    }

    static List<string> RepearString(string readLine, byte count)
    {
        List<string> repearString = new List<string>(count);

        for (int i = 0; i < count; i++)
        {
            repearString.Add(readLine);
        }

        return repearString;
    }

    static void PrintRepearString(List<string> repearString)
    {
        repearString.ForEach(Console.Write);
        Console.WriteLine();
    }
}