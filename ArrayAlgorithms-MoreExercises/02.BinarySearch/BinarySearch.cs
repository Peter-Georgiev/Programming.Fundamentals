using System;
using System.Linq;

class BinarySearch
{
    static void Main()
    {
        int[] firstLine = ReaddLine();
        int secondLine = int.Parse(Console.ReadLine());

        string message = "No";

        byte countLinear = SearchLinear(firstLine, secondLine, ref message);

        byte countBinary = SearchBinary(firstLine, secondLine);

        PrintResult(message, countLinear, countBinary);
    }

    static byte SearchBinary(int[] firstLine, int secondLine)
    {
        Array.Sort(firstLine);

        byte countBinary = 0;
        int lowerBound = 0;
        int upperBound = firstLine.Length - 1;

        while (lowerBound <= upperBound)
        {
            if (lowerBound > upperBound)
            {
                break;
            }

            int midPoint = lowerBound + (upperBound - lowerBound) / 2;
            countBinary++;

            if (firstLine[midPoint] < secondLine)
            {
                lowerBound = midPoint + 1;
            }
            else if (firstLine[midPoint] > secondLine)
            {
                upperBound = midPoint - 1;
            }
            else if (firstLine[midPoint] == secondLine)
            {
                break;
            }
        }

        return countBinary;
    }

    static byte SearchLinear(int[] firstLine, int secondLine, ref string message)
    {
        byte countLinear = 0;

        for (byte i = 0; i < firstLine.Length; i++)
        {
            countLinear = i;
            countLinear++;

            if (firstLine[i] == secondLine)
            {
                message = "Yes";
                break;
            }
        }

        return countLinear;
    }

    static int[] ReaddLine()
    {
        int[] readLine = Console.ReadLine()
            .Split(' ')
            .Select(n => int.Parse(n))
            .ToArray();

        return readLine;
    }

    static void PrintResult(string message, int countLinear, int countBinary)
    {
        Console.WriteLine(message);
        Console.WriteLine("Linear search made {0} iterations", countLinear);
        Console.WriteLine("Binary search made {0} iterations", countBinary);
    }
}
