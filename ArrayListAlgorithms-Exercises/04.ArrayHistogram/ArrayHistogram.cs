using System;
using System.Collections.Generic;
using System.Linq;

class ArrayHistogram
{
    static void Main()
    {
        string[] readLine = ReadLine();

        PrintResult(CuurentList(readLine));
    }

    static string[] CuurentList(string[] readLine)
    {
        List<string> wordsFound = new List<string>();
        List<int> wordsCount = new List<int>();

        for (int i = 0; i < readLine.Length; i++)
        {
            if (wordsFound.Contains(readLine[i]))
            {
                int wordIndex = wordsFound.IndexOf(readLine[i]);
                wordsCount[wordIndex]++;
            }
            else
            {
                wordsFound.Add(readLine[i]);
                wordsCount.Add(1);
            }
        }

        //-------Sort Array Using Bubble Sort-------//
        bool isSwapped = true;

        while (isSwapped)
        {
            isSwapped = false;
            for (int i = 0; i < wordsCount.Count - 1; i++)
            {
                if (wordsCount[i] < wordsCount[i + 1])
                {
                    var tempNum = wordsCount[i];
                    wordsCount[i] = wordsCount[i + 1];
                    wordsCount[i + 1] = tempNum;

                    var tempStr = wordsFound[i];
                    wordsFound[i] = wordsFound[i + 1];
                    wordsFound[i + 1] = tempStr;

                    isSwapped = true;
                }
            }
        }        
        //-----------------------------------------//

        string[] cuurentList = new string[wordsCount.Count];

        for (int i = 0; i < cuurentList.Length; i++)
        {
            double percent = ((double)wordsCount[i] / (double)readLine.Length) * 100d;
            cuurentList[i] = $"{wordsFound[i]} -> {wordsCount[i]} times ({percent:F2}%)";
        }

        return cuurentList;
    }

    static void PrintResult(string[] cuurentList)
    {
        foreach (var print in cuurentList)
        {
            Console.WriteLine(print);
        }
    }

    static string[] ReadLine()
    {
        string[] readLine = Console.ReadLine()
            .Split(' ')
            .ToArray();

        return readLine;
    }
}