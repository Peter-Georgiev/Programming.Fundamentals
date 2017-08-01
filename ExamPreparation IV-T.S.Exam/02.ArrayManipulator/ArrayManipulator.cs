using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (command.Equals("exchange"))
            {
                int index = int.Parse(tokens[1]);
                if (index >=0 && index < array.Count)
                {
                    GetExchangeIndex(array, index);
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
            else if (command.Equals("max"))
            {
                int maxOddOrEvenIndex = GetMaxEvenOrOdd(array, tokens);
                if (maxOddOrEvenIndex < 0)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(maxOddOrEvenIndex); ;
                }
            }
            else if (command.Equals("min"))
            {
                int minOddOrEvenIndex = GetMinEvenOrOdd(array, tokens);
                if (minOddOrEvenIndex > 1000)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(minOddOrEvenIndex); ;
                }
            }
            else if (command.Equals("first"))
            {
                //int firstCount = int.Parse(tokens[1]);
                //if (firstCount >= 0 && firstCount < array.Count)
                //{
                //    GetFirstEvenOrOddElements(array, tokens);
                //}
                //else
                //{
                //    Console.WriteLine("Invalid index");
                //}
            }
            else if (command.Equals("last"))
            {

            }
        }

        Console.WriteLine();
    }

    private static void GetFirstEvenOrOddElements(List<int> array, object index)
    {
        throw new NotImplementedException();
    }

    private static int GetMinEvenOrOdd(List<int> array, string[] tokens)
    {
        int index = int.MaxValue;

        if (index + 1 % 2 != 0)
        {

        }
        if (tokens[1].Equals("odd"))
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] < index + 1 && array[i] % 2 != 0)
                {
                    index = i;
                }
            }
        }
        else if (tokens[1].Equals("even"))
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] < index && array[i] % 2 == 0)
                {
                    index = i;
                }
            }
        }

        return index;
    }

    private static int GetMaxEvenOrOdd(List<int> array, string[] tokens)
    {
        int index = int.MinValue;

        if (tokens[1].Equals("odd"))
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] > index + 1 && array[i] % 2 != 0)
                {
                    index = i;
                }
            }
        }
        else if (tokens[1].Equals("even"))
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] > index && array[i] % 2 == 0)
                {
                    index = i;
                }
            }
        }

        return index;
    }

    private static void GetExchangeIndex(List<int> array, int index)
    {
        List<int> tempArr =  array
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