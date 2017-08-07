using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class BoomingCannon
{
    static void Main()
    {
        int[] tokens = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        string readLine = Console.ReadLine();

        Match regex = Regex.Match(readLine, @"\\<<<.+");

        readLine = regex.Value.Trim();

        string[] text = Regex.Split(readLine, @"\\<<<")
            .Where(x => x.Length > 0)
            .Select(x => x.Trim())
            .ToArray();

        List<string> result = new List<string>();

        for (int i = 0; i < text.Length; i++)
        {
            string booming = String.Join("", text[i]
                .Skip(tokens[0])
                .Take(tokens[1]));
            if (booming != String.Empty)
            {
                result.Add(booming);
            }
        }

        Console.WriteLine(String.Join("/\\", result));
    }
}