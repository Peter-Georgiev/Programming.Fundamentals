using System;
using System.Linq;
using System.Collections.Generic;

class CommandInterpreter
{
    static void Main()
    {
        List<string> input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        List<string> result = new List<string>();

        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("end"))
            {
                break;
            }

            string[] tokens = command
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            
            result.Clear();

            if (tokens[0].Equals("reverse"))
            {
                GetRevers(tokens, input, result);
            }
            else if (tokens[0].Equals("sort"))
            {
                GetSorted(tokens, input, result);
            }
            else if (tokens[0].Equals("rollLeft"))
            {
                GetRollLeft(tokens, input, result);
            }
            else if (tokens[0].Equals("rollRight"))
            {
                GetRollRight(tokens, input, result);
            }
            input.Clear();
            input.AddRange(result);
        }

        Console.WriteLine("[" + string.Join(", ", result) + "]");
    }

    static void GetRollRight(string[] tokens, List<string> input, List<string> result)
    {
        int count = int.Parse(tokens[1]) % input.Count;

        for (int times = 0; times < count; times++)
        {
            string lastEment = input[input.Count - 1];

            for (int i = input.Count - 1; i > 0; i--)
            {
                input[i] = input[i - 1];

            }

            input[0] = lastEment;
        }

        result.AddRange(input);
    }

    static void GetRollLeft(string[] tokens, List<string> input, List<string> result)
    {
        int count = int.Parse(tokens[1]) % input.Count;

        for (int times = 0; times < count; times++)
        {
            string firstIndex = input[0];

            for (int i = 0; i < input.Count - 1; i++)
            {
                input[i] = input[i + 1];
            }

            input[input.Count - 1] = firstIndex;
        }

        result.AddRange(input);
    }

    static void GetSorted(string[] tokens, List<string> input, List<string> result)
    {
        int fromIndex = int.Parse(tokens[2]);
        int count = int.Parse(tokens[4]);

        if ((fromIndex < 0 || fromIndex >= input.Count) ||
            (fromIndex + count < 0 || fromIndex + count >= input.Count))
        {
            PrindInvalidInput();
            result.AddRange(input);
        }
        else
        {
            var tempList = input
                .Skip(fromIndex)
                .Take(count)
                .OrderBy(x => x)
                .ToList();

            bool isEqualIndex = false;
            int indexTemp = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (i.Equals(fromIndex))
                {
                    isEqualIndex = true;
                }
                else if (i.Equals(fromIndex + count))
                {
                    isEqualIndex = false;
                }

                if (isEqualIndex)
                {
                    result.Add(tempList[indexTemp]);
                    indexTemp++;
                }
                else
                {
                    result.Add(input[i]);
                }
            }
        }
    }

    static void GetRevers(string[] tokens, List<string> input, List<string> result)
    {
        int fromIndex = int.Parse(tokens[2]);
        int count = int.Parse(tokens[4]);

        if ((fromIndex < 0 || fromIndex >= input.Count) ||
            (fromIndex + count < 0 || fromIndex + count >= input.Count))
        {
            PrindInvalidInput();
            result.AddRange(input);
        }
        else
        {
            var tempList = input
                .Skip(fromIndex)
                .Take(count)
                .Reverse()
                .ToList();

            bool isEqualIndex = false;
            int indexTemp = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (i.Equals(fromIndex))
                {
                    isEqualIndex = true;
                }
                else if (i.Equals(fromIndex + count))
                {
                    isEqualIndex = false;
                }

                if (isEqualIndex)
                {
                    result.Add(tempList[indexTemp]);
                    indexTemp++;
                }
                else
                {
                    result.Add(input[i]);
                }
            }
        }
    }

    static void PrindInvalidInput()
    {
        Console.WriteLine("Invalid input parameters.");
    }
}