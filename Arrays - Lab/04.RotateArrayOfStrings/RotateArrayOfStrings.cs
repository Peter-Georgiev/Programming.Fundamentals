using System;
using System.Linq;

class RotateArrayOfStrings
{
    static void Main()
    {
        string[] readLine = Console.ReadLine()
            .Split(' ')
            .ToArray();

        var temp = readLine[readLine.Length - 1];

        for (int i = readLine.Length - 2; i >= 0; i--)
        {
            readLine[i + 1] = readLine[i];
        }

        readLine[0] = temp;

        Console.WriteLine(string.Join(" ", readLine));
    }
}