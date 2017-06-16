using System;
using System.Collections.Generic;
using System.Linq;

class ShootListElements
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        List<string> output = new List<string>();
        int lastRemove = 0;
        bool isBreak = false;

        while (!isBreak)
        {
            string readLine = Console.ReadLine();

            GetResult(numbers, output, ref lastRemove, ref isBreak, readLine);

            isBreak = PrintResultAndExit(numbers, output, lastRemove, isBreak, readLine);
        }
    }

    private static void GetResult(List<int> numbers, List<string> output, ref int lastRemove, ref bool isBreak, string readLine)
    {
        if (readLine.Equals("bang"))
        {
            if (!numbers.Count.Equals(0))
            {
                var average = numbers.Average();
                var minNum = average;
                bool isShort = false;

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] < minNum || numbers.Count.Equals(1))
                    {
                        minNum = numbers[i];
                        isShort = true;
                        break;
                    }
                }

                if (isShort)
                {
                    numbers.Remove((int)(minNum));
                    lastRemove = (int)minNum;
                    output.Add($"shot {Convert.ToString(minNum)}");

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i]--;
                    }
                }
            }
            else
            {
                isBreak = true;
            }
        }
        else if (!readLine.Equals("stop"))
        {
            numbers.Insert(0, int.Parse(readLine));
        }
    }

    private static bool PrintResultAndExit(List<int> numbers, List<string> output, int lastRemove, bool isBreak, string readLine)
    {
        if (isBreak)
        {
            output.Add($"nobody left to shoot! last one was {lastRemove}");
            output.ForEach(Console.WriteLine);
        }
        else if (readLine.Equals("stop"))
        {
            if (numbers.Count == 0)
            {
                output.Add($"you shot them all. last one was {lastRemove}");
                output.ForEach(Console.WriteLine);
                isBreak = true;
            }
            else if (numbers.Count >= 1)
            {
                output.ForEach(Console.WriteLine);
                Console.WriteLine($"survivors: {string.Join(" ", numbers)}");
                isBreak = true;
            }
        }

        return isBreak;
    }
}