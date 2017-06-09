using System;
using System.Collections.Generic;
using System.Linq;

class StuckZipper
{
    static void Main()
    {
        int[] firstLine = ReadLine();
        int[] secondLine = ReadLine();

        List<int> zipping = ZippingLine(firstLine, secondLine);

        Console.WriteLine(string.Join(" ", zipping));
    }

    private static int[] ReadLine()
    {
        int[] readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        return readLine;
    }

    private static List<int> ZippingLine(int[] firstLine, int[] secondLine)
    {
        List<int> zippingLine = new List<int>();
        byte countFirstLine = 0;
        byte countSecondLine = 0;

        for (int i = 0; i < firstLine.Length + secondLine.Length; i++)
        {
            if (i % 2 == 0)
            {
                zippingLine.Add(secondLine[countSecondLine]);
                countSecondLine++;
            }
            else
            {
                zippingLine.Add(firstLine[countFirstLine]);
                countFirstLine++;
            }
        }

        return zippingLine;
    }
}