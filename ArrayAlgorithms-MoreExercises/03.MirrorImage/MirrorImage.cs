using System;
using System.Collections.Generic;
using System.Linq;

class MirrorImage
{
    static void Main()
    {
        string[] input = Console.ReadLine()
            .Split(' ')
            .ToArray();

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("Print"))
            {
                break;
            }

            int n = int.Parse(readLine);

            input = Reverset(input, 0, n - 1);
            input = Reverset(input, n + 1, input.Length - 1);
        }

        Console.WriteLine(string.Join(" ", input));
    }

    static string[] Reverset(string[] arr, int first, int last)
    {
        List<string> temp = new List<string>();

        for (int i = last; i >= first; i--)
        {
            temp.Add(arr[i]);
        }

        for (int i = 0; i < temp.Count; i++)
        {
            arr[i + first] = temp[i];
        }

        return arr;
    }
}