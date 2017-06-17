using System;
using System.Collections.Generic;
using System.Linq;

class DecodeRadioFrequencies
{
    static void Main()
    {
        string[] readLine = ReadLine();

        List<char> convertToCharacte = ConvertToCharacter(readLine);

        PrintResult(convertToCharacte);
    }
    static void PrintResult(List<char> convertToCharacte)
    {
        Console.WriteLine(string.Join("", convertToCharacte));
    }

    static List<char> ConvertToCharacter(string[] readLine)
    {
        List<char> leftConvert = new List<char>();
        List<char> rightConvert = new List<char>();

        for (int i = 0; i < readLine.Length; i++)
        {
            int[] separated = readLine[i]
                .Split('.')
                .Select(int.Parse)
                .ToArray();

            if (separated[0] != 0)
            {
                leftConvert.Add((char)separated[0]);
            }

            if (separated[1] != 0)
            {
                rightConvert.Add((char)separated[1]);
            } 
        }

        rightConvert.Reverse();

        leftConvert.AddRange(rightConvert);

        return leftConvert;
    }

    static string[] ReadLine()
    {
        string[] readLine = Console.ReadLine()
            .Split(' ')
            .ToArray();

        return readLine;
    }

}