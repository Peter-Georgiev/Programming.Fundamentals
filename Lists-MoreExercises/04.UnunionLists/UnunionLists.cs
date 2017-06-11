using System;
using System.Collections.Generic;
using System.Linq;

class UnunionLists
{
    static void Main()
    {
        List<int> readListLine = ReadListLine();

        byte count = byte.Parse(Console.ReadLine());

        while (count > 0)
        {
            var readLine = ReadListLine();

            readListLine = RemoveElements(readListLine, readLine);

            count--;
        }

        PrintList(readListLine);
    }
    
    private static List<int> ReadListLine()
    {
        List<int> readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        return readLine;
    }

    private static List<int> RemoveElements(List<int> readListLine, List<int> readLine)
    {
        for (int j = 0; j < readLine.Count; j++)
        {
            if (readListLine.Contains(readLine[j]))
            {
                readListLine = readListLine.FindAll(x => x != readLine[j]);
                readLine.RemoveAt(j);
                j--;
            }
        }

        readListLine.AddRange(readLine);
        readListLine.Sort();

        return readListLine;
    }

    private static void PrintList(List<int> readListLine)
    {
        Console.WriteLine(string.Join(" ", readListLine));
    }
}