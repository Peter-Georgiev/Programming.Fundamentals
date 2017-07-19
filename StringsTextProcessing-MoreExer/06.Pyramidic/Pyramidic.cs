using System;
using System.Collections.Generic;
using System.Linq;

class Pyramidic
{
    static void Main()
    {
        List<string> pyramidis = new List<string>();

        string[] input = ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            string currentLine = input[i];

            for (int j = 0; j < currentLine.Length; j++)
            {
                string currentPyramid = FindPiramid(input, i, currentLine, j);

                pyramidis.Add(currentPyramid.Trim());
            }
        }

        PrintPyramids(pyramidis);
    }

    static string FindPiramid(string[] input, int i, string currentLine, int j)
    {
        char currenetCharecter = currentLine[j];
        int layer = 1;
        string currentPyramid = String.Empty;

        for (int k = i; k < input.Length; k++)
        {
            string currentLayer = new string(currenetCharecter, layer);

            if (input[k].Contains(currentLayer))
            {
                currentPyramid += currentLayer + Environment.NewLine;
            }
            else
            {
                break;
            }

            layer += 2;
        }

        return currentPyramid;
    }

    static void PrintPyramids(List<string> pyramidis)
    {
        pyramidis
            .OrderByDescending(x => x.Length)
            .First()
            .ToList()
            .ForEach(x => Console.Write(x));
        Console.WriteLine();
    }

    static string[] ReadLine()
    {
        byte n = byte.Parse(Console.ReadLine());
        string[] input = new string[n];

        for (byte i = 0; i < n; i++)
        {
            string readLine = Console.ReadLine();
            input[i] = readLine.Trim();
        }

        return input;
    }
}