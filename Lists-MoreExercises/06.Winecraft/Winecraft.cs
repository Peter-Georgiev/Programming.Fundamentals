using System;
using System.Linq;
using System.Collections.Generic;

class Winecraft
{
    static void Main()
    {
        List<int> readLine = ReadLine();

        int n = byte.Parse(Console.ReadLine());

        bool hasExit = true;

        while (hasExit)
        {
            for (int count = 1; count <= n; count++)
            {
                AddGrapes(readLine);

                RemovePreviousAndNextIndex(readLine);
            }

            bool hasCount = readLine.FindAll(x => x > n).Count < n && n >= readLine.Min();
            
            if (!hasCount)
            {
                for (int set = 0; set < readLine.Count; set++)
                {
                    if (readLine[set] < n)
                    {
                        readLine[set] = 0;
                    }
                }

                hasExit = true;
            }
            else
            {
                hasExit = false;
            }
        }        

        PrintGrapes(readLine, n);
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

                bool hasLeftAndOneGrapes = 
                    readLine[i] > readLine[previousIndex] && readLine[i] > readLine[nextIndex];

                if (hasLeftAndOneGrapes)
                {
                    if (readLine[previousIndex] > 0)
                    {
                        readLine[i]++;
                        readLine[previousIndex] = Math.Max(readLine[previousIndex] - 1, 0);
                    }

                    if (readLine[nextIndex] > 0)
                    {
                        readLine[i]++;
                        readLine[nextIndex] = Math.Max(readLine[nextIndex] - 1, 0);
                    }
                }
            }
        }
    }

    static void AddGrapes(List<int> readLine)
    {
        for (int i = 0; i < readLine.Count; i++)
        {
            if (readLine[i] > 0)
            {
                readLine[i]++;
            }            
        }

        bool hasNextIndex = false;

        for (int i = 0; i < readLine.Count; i++)
        {
            bool hasFirstReadLine = i == 0;
            bool hasLastReadLine = i == readLine.Count - 1;

            if (!hasFirstReadLine && !hasLastReadLine)
            {
                int previousIndex = i - 1;
                int nextIndex = i + 1;

                bool hasLeftAndOneGrapes =
                    readLine[i] > readLine[previousIndex] && readLine[i] > readLine[nextIndex];

                if (hasLeftAndOneGrapes)
                {
                    if (hasNextIndex)
                    {
                        hasNextIndex = false;
                    }
                    else
                    {
                        readLine[previousIndex] = Math.Max(readLine[previousIndex] - 1, 0);
                    }

                    readLine[nextIndex] = Math.Max(readLine[nextIndex] - 1, 0);
                    hasNextIndex = true;
                }
            }
        }
    }

    static void PrintGrapes(List<int> readLine, int n)
    {
        Console.WriteLine(string.Join(" ", readLine.FindAll(x => x > n)));
    }

    static List<int> ReadLine()
    {
        var readLLine = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        return readLLine;
    }
}