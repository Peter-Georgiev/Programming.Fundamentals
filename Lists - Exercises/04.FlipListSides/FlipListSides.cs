using System;
using System.Collections.Generic;
using System.Linq;

class FlipListSides
{
    static void Main()
    {
        List<int> readLine = ReadLine();

        List<int> tempLineToRevers = new List<int>(readLine.Count);
        List<int> tempList = new List<int>(3);

        for (int i = 0; i < readLine.Count; i++)
        {
            bool isTempArr = i == 0 || i + 1 == readLine.Count;

            if (isTempArr)
            {
                tempList.Add(readLine[i]);
            }
            else
            {
                tempLineToRevers.Add(readLine[i]);
            }
        }

        if (tempLineToRevers.Count % 2 != 0)
        {
            tempList.Add(tempLineToRevers[tempLineToRevers.Count / 2]);
            tempLineToRevers.RemoveAt(tempLineToRevers.Count / 2);
        }

        tempLineToRevers.Reverse();
        readLine = tempLineToRevers;

        PrintList(readLine, tempList);
    }

    private static List<int> ReadLine()
    {
        List<int> readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        return readLine;
    }

    private static void PrintList(List<int> readLine, List<int> tempList)
    {
        if (tempList.Count.Equals(3))
        {
            readLine.Insert(0, tempList[0]);
            readLine.Insert((readLine.Count / 2) + 1, tempList[2]);
            readLine.Add(tempList[1]);
        }
        else
        {
            readLine.Insert(0, tempList[0]);
            readLine.Add(tempList[1]);
        }

        Console.WriteLine(string.Join(" ", readLine));
    }
}