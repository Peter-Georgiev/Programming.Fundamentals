using System;
using System.Collections.Generic;
using System.Linq;

class ArrayManipulator
{
    static void Main()
    {
        List<int> arr = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        string readLine;
        while ((readLine = Console.ReadLine()) != "end")
        {
            string[] tokens = readLine
                .Split(' ')
                .ToArray();

            if (tokens[0] == "exchange")
            {
                arr = CommandExchange(arr, tokens[1]);
            }
            else if (tokens[0] == "max")
            {
                CommandMaxEvenOdd(arr, tokens[1]);
            }
            else if (tokens[0] == "min")
            {
                CommandMinEvenOdd(arr, tokens[1]);
            }
            else if (tokens[0] == "first")
            {
                CommandFirstEvenOdd(arr, tokens);
            }
            else if (tokens[0] == "last")
            {
                CommandLastEvenOdd(arr, tokens);
            }
        }

        Console.WriteLine("[" + String.Join(", ", arr) + "]");
    }

    private static void CommandLastEvenOdd(List<int> arr, string[] tokens)
    {
        int count = int.Parse(tokens[1]);
        string s = tokens[2];

        if (!(count > 0 && count <= arr.Count))
        {
            Console.WriteLine("Invalid count");
            return;
        }

        if (s == "odd")
        {
            int[] countOdd = arr
                .Where(x => x % 2 != 0)
                .Reverse()
                .Take(count)
                .Reverse()
                .ToArray();
            Console.WriteLine("[" + String.Join(", ", countOdd) + "]");
        }

        if (s == "even")
        {
            int[] countOdd = arr
                .Where(x => x % 2 == 0)
                .Reverse()
                .Take(count)
                .Reverse()
                .ToArray();
            Console.WriteLine("[" + String.Join(", ", countOdd) + "]");
        }
    }

    private static void CommandFirstEvenOdd(List<int> arr, string[] tokens)
    {
        int count = int.Parse(tokens[1]);
        string s = tokens[2];

        if (!(count > 0 && count <= arr.Count))
        {
            Console.WriteLine("Invalid count");
            return;
        }

        if (s == "odd")
        {
            int[] countOdd = arr
                .Where(x => x % 2 != 0)
                .Take(count)
                .ToArray();
            Console.WriteLine("[" + String.Join(", ", countOdd) + "]");
        }

        if (s == "even")
        {
            int[] countOdd = arr
                .Where(x => x % 2 == 0)
                .Take(count)
                .ToArray();
            Console.WriteLine("[" + String.Join(", ", countOdd) + "]");
        }
    }

    private static void CommandMinEvenOdd(List<int> arr, string s)
    {
        if (s == "odd" && arr.Where(x => x % 2 != 0).ToArray().Length > 0)
        {
            int maxOddIndex = arr
                .LastIndexOf(arr.Where(x => x % 2 != 0)
                .Min());
            Console.WriteLine(maxOddIndex);
        }
        else if (s == "odd")
        {
            Console.WriteLine("No matches");
        }

        if (s == "even" && arr.Where(x => x % 2 == 0).ToArray().Length > 0)
        {
            int maxEvenIndex = arr
                .LastIndexOf(arr.Where(x => x % 2 == 0)
                .Min());
            Console.WriteLine(maxEvenIndex);
        }
        else if (s == "even")
        {
            Console.WriteLine("No matches");
        }
    }

    private static void CommandMaxEvenOdd(List<int> arr, string s)
    {
        if (s == "odd" && arr.Where(x => x % 2 != 0).ToArray().Length > 0)
        {
            int maxOddIndex = arr
                .LastIndexOf(arr.Where(x => x % 2 != 0)
                .Max());
            Console.WriteLine(maxOddIndex);
        }
        else if (s == "odd")
        {
            Console.WriteLine("No matches");
        }

        if (s == "even" && arr.Where(x => x % 2 == 0).ToArray().Length > 0)
        {
            int maxEvenIndex = arr
                .LastIndexOf(arr.Where(x => x % 2 == 0)
                .Max());
            Console.WriteLine(maxEvenIndex);
        }
        else if (s == "even")
        {
            Console.WriteLine("No matches");
        }
    }

    private static List<int> CommandExchange(List<int> arr, string s)
    {
        int index = int.Parse(s.Trim());
        if (!(index >= 0 && index < arr.Count))
        {
            Console.WriteLine("Invalid index");
            return arr;
        }

        List<int> takeArr = arr
            .Skip(index + 1)
            .ToList();
        arr.RemoveRange(index + 1, takeArr.Count);
        takeArr.AddRange(arr);
        return takeArr;
    }
}