using System;
using System.Linq;
using System.Collections.Generic;

class Winecraft
{
    static void Main()
    {
        var readLine = ReadLine();
        int n = byte.Parse(Console.ReadLine());

        readLine = AddAndRemoveGrapes(readLine, n);

        PrintGrapes(readLine);
    }      

    private static List<int> ReadLine()
    {
        var readLLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        return readLLine;
    }

    private static List<int> AddAndRemoveGrapes(List<int> readLine, int n)
    {        
        while (readLine.Count > n)
        {
            for (int count = 0; count < n; count++)
            {
                AddGrapes(readLine);
                RemovePreviousAndNextIndex(readLine);
            }

            readLine = readLine.FindAll(x => x > n);
        }

        return readLine;
    }

    private static void RemovePreviousAndNextIndex(List<int> readLine)
    {
        for (int i = 0; i < readLine.Count; i++)
        {
            bool isFirstReadLine = i == 0;
            bool isLastReadLine = i == readLine.Count - 1;

            if (!isFirstReadLine && !isLastReadLine)
            {
                int previousIndex = i - 1;
                int nextIndex = i + 1;

                bool isLeftAndOneGrapes = readLine[i] > readLine[previousIndex]
                    && readLine[i] > readLine[nextIndex];

                if (isLeftAndOneGrapes)
                {
                    readLine[i]--;

                    if (readLine[previousIndex] > 0)
                    {
                        readLine[i]++;
                        readLine[previousIndex] = Math.Max(readLine[previousIndex] - 2, 0);
                    }

                    if (readLine[nextIndex] > 0)
                    {
                        readLine[i]++;
                        readLine[nextIndex] = Math.Max(readLine[nextIndex] - 2, 0);
                    }
                }
            }
        }
    }

    private static void AddGrapes(List<int> readLine)
    {
        for (int i = 0; i < readLine.Count; i++)
        {
            readLine[i]++;
        }
    }

    private static void PrintGrapes(List<int> readLine)
    {
        Console.WriteLine(string.Join(" ", readLine));
    }
}