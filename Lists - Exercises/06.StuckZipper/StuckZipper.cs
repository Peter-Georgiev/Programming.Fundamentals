using System;
using System.Collections.Generic;
using System.Linq;

class StuckZipper
{
    static void Main()
    {
        List<int> firstLine = ReadLine();
        List<int> secondLine = ReadLine();

        int minCount = FindMinDigits(firstLine, secondLine);

        firstLine = RemoveElements(minCount, firstLine);
        secondLine = RemoveElements(minCount, secondLine);

        PrintZippingLine(firstLine, secondLine);
    }

    private static List<int> ReadLine()
    {
        List<int> readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        return readLine;
    }

    private static int FindMinDigits(List<int> firstLine, List<int> secondLine)
    {
        string strFirst = firstLine
            .Min(x => Math.Abs(x))
            .ToString();
        int nFirst = strFirst.Length;

        string strSecond = secondLine
            .Min(x => Math.Abs(x))
            .ToString();
        int nSecond = strSecond.Length;

        int findMinDigits = Math.Min(nFirst, nSecond);

        return findMinDigits;
    }

    private static List<int> RemoveElements(int minCount, List<int> inputLine)
    {
        for (int i = 0; i < inputLine.Count; i++)
        {
            byte count = 0;
            int currentNumber = Math.Abs(inputLine[i]);

            while (currentNumber > 0)
            {
                currentNumber /= 10;
                count++;
            }

            if (count > minCount)
            {
                inputLine.RemoveAt(i);
                i--;
            }
        }        

        return inputLine;
    }

    private static void PrintZippingLine(List<int> firstLine, List<int> secondLine)
    {
        List<int> zippingLine = new List<int>(firstLine.Count + secondLine.Count);
        byte countFirstLine = 0;
        byte countSecondLine = 0;

        if (firstLine.Count.Equals(0))
        {
            zippingLine = secondLine;
        }
        else if (secondLine.Count.Equals(0))
        {
            zippingLine = firstLine;
        }
        else
        {
            for (int i = 0; i < firstLine.Count + secondLine.Count; i++)
            {
                if (i % 2 == 0 && secondLine.Count > countSecondLine)
                {
                    zippingLine.Add(secondLine[countSecondLine]);
                    countSecondLine++;
                }
                else if (firstLine.Count > countFirstLine)
                {
                    zippingLine.Add(firstLine[countFirstLine]);
                    countFirstLine++;
                }
                else if (secondLine.Count > countSecondLine)
                {
                    zippingLine.Add(secondLine[countSecondLine]);
                    countSecondLine++;
                }
            }
        }

        Console.WriteLine(string.Join(" ", zippingLine));
    }
}