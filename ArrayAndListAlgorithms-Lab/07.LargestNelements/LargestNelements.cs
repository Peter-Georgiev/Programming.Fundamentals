using System;
using System.Linq;

class LargestNelements
{
    static void Main()
    {
        int[] readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        byte n = byte.Parse(Console.ReadLine());

        readLine = InsertionSort(readLine);

        int[] printLine = new int[n];
        printLine = GetLargestNelements(readLine, n, printLine);
        
        Console.WriteLine(string.Join(" ", printLine));
    }

    private static int[] GetLargestNelements(int[] readLine, byte n, int[] printLine)
    {
        int lastNnumber = readLine.Length - n;
        byte countPrint = 0;
        for (int i = lastNnumber; i < readLine.Length; i++, countPrint++)
        {
            printLine[countPrint] = readLine[i];
        }

        Array.Reverse(printLine);
        return printLine;
    }

    private static int[] InsertionSort(int[] readLine)
    {
        for (int i = 0; i < readLine.Length; i++)
        {
            int current = readLine[i];
            int previous = i - 1;

            while (previous >= 0 && readLine[previous] > current)
            {
                readLine[previous + 1] = readLine[previous];
                previous--;
            }

            readLine[previous + 1] = current;
        }
        return readLine;
    }
}