using System;
using System.Collections.Generic;
using System.Linq;

class ArrayManipulator
{
    static void Main()
    {
        List<int> array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("end"))
            {
                break;
            }

            string[] tokens = command
                .Split(' ')
                .ToArray();
            command = tokens[0];

            switch (command)
            {
                case "exchange":
                    int index = int.Parse(tokens[1]);
                    if (index >= 0 && index < array.Count)
                    {
                        GetExchangeIndex(array, index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                    break;

                case "max":
                    int maxOddOrEvenIndex = GetMaxEvenOrOdd(array, tokens);
                    if (maxOddOrEvenIndex < 0)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(maxOddOrEvenIndex);
                    }
                    break;

                case "min":
                    int minOddOrEvenIndex = GetMinEvenOrOdd(array, tokens);
                    if (tokens[1] == "odd" && minOddOrEvenIndex <= 1000)
                    {
                        Console.WriteLine(minOddOrEvenIndex);
                    }
                    else if (tokens[1] == "even" && minOddOrEvenIndex <= 1000)
                    {
                        Console.WriteLine(minOddOrEvenIndex);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                    break;

                case "first":
                    int firstCount = int.Parse(tokens[1]);

                    if (firstCount <= array.Count)
                    {
                        List<int> resultFirstElements =
                        GetFirstEvenOrOddElements(array, tokens);
                        PrintResult(resultFirstElements);
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                    break;

                case "last":
                    int lastCount = int.Parse(tokens[1]);

                    if (lastCount <= array.Count)
                    {
                        List<int> resultLastElements =
                        GetLastEvenOrOddElements(array, tokens);
                        PrintResult(resultLastElements);
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                    break;
            }
        }

        PrintResult(array);
    }

    private static List<int> GetLastEvenOrOddElements(List<int> array, string[] tokens)
    {
        List<int> resultLastElements = new List<int>();
        int lastCount = int.Parse(tokens[1]);

        if (tokens[2].Equals("odd"))
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] % 2 != 0)
                {
                    resultLastElements.Add(array[i]);
                }
            }
        }
        else if (tokens[2].Equals("even"))
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] % 2 == 0)
                {
                    resultLastElements.Add(array[i]);
                }
            }
        }

        List<int> result = new List<int>(lastCount);
        for (int i = resultLastElements.Count - 1; i >= 0; i--)
        {
            if (lastCount > 0)
            {
                result.Add(resultLastElements[i]);
                lastCount--;
            }
        }
        result.Reverse();

        return result;
    }

    private static List<int> GetFirstEvenOrOddElements(List<int> array, string[] tokens)
    {
        List<int> resultFirstElements = new List<int>();
        int firstCount = int.Parse(tokens[1]);

        if (tokens[2].Equals("odd"))
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] % 2 != 0 && resultFirstElements.Count < firstCount)
                {
                    resultFirstElements.Add(array[i]);
                }
            }
        }
        else if (tokens[2].Equals("even"))
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] % 2 == 0 && resultFirstElements.Count < firstCount)
                {
                    resultFirstElements.Add(array[i]);
                }
            }
        }

        return resultFirstElements;
    }

    private static int GetMinEvenOrOdd(List<int> array, string[] tokens)
    {
        int tempArr = int.MaxValue;
        int index = int.MaxValue;

        if (tokens[1].Equals("odd"))
        {
            for (int i = 0; i < array.Count; i++)
            {
                if ((array[i] <= tempArr) && (array[i] % 2 != 0))
                {
                    tempArr = array[i];
                    index = i;
                }
            }
        }
        else if (tokens[1].Equals("even"))
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] <= tempArr && array[i] % 2 == 0)
                {
                    tempArr = array[i];
                    index = i;
                }
            }
        }

        return index;
    }

    private static int GetMaxEvenOrOdd(List<int> array, string[] tokens)
    {
        int tempArr = int.MinValue;
        int index = int.MinValue;

        if (tokens[1].Equals("odd"))
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] >= tempArr && array[i] % 2 != 0)
                {
                    tempArr = array[i];
                    index = i;
                }
            }
        }
        else if (tokens[1].Equals("even"))
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] >= tempArr && array[i] % 2 == 0)
                {
                    tempArr = array[i];
                    index = i;
                }
            }
        }

        return index;
    }

    private static void GetExchangeIndex(List<int> array, int index)
    {
        List<int> tempArr = array
            .Skip(index + 1)
            .Take(array.Count - (index + 1))
            .ToList();
        array
            .RemoveRange(index + 1, array.Count - (index + 1));
        array
            .InsertRange(0, tempArr);
    }

    private static void PrintResult(List<int> array)
    {
        Console.WriteLine($"[{string.Join(", ", array)}]");
    }
}