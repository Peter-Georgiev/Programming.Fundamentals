using System;
using System.Linq;
using System.Collections.Generic;

class CommandInterpreter
{
    static void Main()
    {
        List<string> array = Console.ReadLine()
            .Trim()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        
        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("end"))
            {
                break;
            }

            string[] commandParams = command
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            command = commandParams[0];

            switch (command)
            {
                case "reverse":
                    int reverseStart = int.Parse(commandParams[2]);
                    int reverseCount = int.Parse(commandParams[4]);
                    
                    if (IsValid(array, reverseStart, reverseCount))
                    {
                        Reverse(array, reverseStart, reverseCount);
                    }
                    else
                    {
                        PrindInvalidInput();
                    }

                    break;
                case "sort":
                    int sortStart = int.Parse(commandParams[2]);
                    int sortCount = int.Parse(commandParams[4]);

                    if (IsValid(array, sortStart, sortCount))
                    {
                        Sorted(array, sortStart, sortCount);
                    }
                    else
                    {
                        PrindInvalidInput();
                    }

                    break;
                case "rollLeft":
                    int rollLeftCount = int.Parse(commandParams[1]);

                    if (rollLeftCount >= 0)
                    {
                        RollLeft(array, rollLeftCount);
                    }
                    else
                    {
                        PrindInvalidInput();
                    }

                    break;
                case "rollRight":
                    int rollRightCount = int.Parse(commandParams[1]);

                    if (rollRightCount >= 0)
                    {
                        RollRight(array, rollRightCount);
                    }
                    else
                    {
                        PrindInvalidInput();
                    }

                    break;
            }
        }

        Console.WriteLine("[" + string.Join(", ", array) + "]");
    }

    static void RollRight(List<string> array, int rollRightCount)
    {
        int count = rollRightCount % array.Count;

        for (int times = 0; times < count; times++)
        {
            string lastEment = array[array.Count - 1];

            for (int i = array.Count - 1; i > 0; i--)
            {
                array[i] = array[i - 1];

            }

            array[0] = lastEment;
        }
    }

    static void RollLeft(List<string> array, int rollLeftCount)
    {
        int count = rollLeftCount % array.Count;

        for (int times = 0; times < count; times++)
        {
            string firstIndex = array[0];

            for (int i = 0; i < array.Count - 1; i++)
            {
                array[i] = array[i + 1];
            }

            array[array.Count - 1] = firstIndex;
        }
    }

    static void Sorted(List<string> array, int sortStart, int sortCount)
    {
        array.Sort(sortStart, sortCount, StringComparer.CurrentCulture);
    }

    static void Reverse(List<string> array, int reverseStart, int reverseCount)
    {
        array.Reverse(reverseStart, reverseCount);
    }

    static bool IsValid(List<string> array, int reverseStart, int reverseCount)
    {
        if (reverseStart >= 0 && reverseStart < array.Count &&
            reverseCount >= 0 && (reverseStart + reverseCount) <= array.Count)
        {
            return true;
        }

        return false;
    }
        
    static void PrindInvalidInput()
    {
        Console.WriteLine("Invalid input parameters.");
    }
}