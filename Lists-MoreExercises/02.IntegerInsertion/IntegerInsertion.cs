using System;
using System.Collections.Generic;
using System.Linq;

class IntegerInsertion
{
    static void Main()
    {
        List<int> readFirstLine = ReadFirstLine();
        List<int> readSecondLine = ReadSecondLine();
        
        PrintResult(readFirstLine, readSecondLine);
    }

    private static List<int> ReadFirstLine()
    {
        List<int> readFirstLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();        

        return readFirstLine;
    }

    private static List<int> ReadSecondLine()
    {
        List<int> readSecondLine = new List<int>();

        string readStr = Console.ReadLine();

        while (!readStr.Equals("end"))
        {
            readSecondLine.Add(int.Parse(readStr));

            readStr = Console.ReadLine();
        }

        return readSecondLine;
    }

    private static void PrintResult(List<int> readFirstLine, List<int> readSecondLine)
    {
        for (int i = 0; i < readSecondLine.Count; i++)
        {
            string word = Convert.ToString(readSecondLine[i]);
            int letter = int.Parse(Convert.ToString(word[0]));

            readFirstLine.Insert(letter, readSecondLine[i]);

            readSecondLine.RemoveAt(i);

            i--;
        }

        Console.WriteLine(string.Join(" ", readFirstLine));
    }
}