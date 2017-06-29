using System;
using System.Collections.Generic;
using System.Linq;

class Extremums
{
    static void Main()
    {
        List<string> input = ReadLine();
        string commant = Console.ReadLine();

        List<int> output = new List<int>();
                
        int sum = 0;

        if (commant.Equals("Min"))
        {
            MinValue(input, output, ref sum);
        }
        else if (commant.Equals("Max"))
        {
            MaxValue(input, output, ref sum);
        }

        PrintResult(output);
    }

    static void MinValue(List<string> input, List<int> output, ref int sum)
    {
        int minValue = int.MaxValue;

        for (int i = 0; i < input.Count; i++)
        {
            string element = input[i];

            byte index = 0;

            while (index <= element.Length)
            {
                if (int.Parse(element) < minValue)
                {
                    minValue = int.Parse(element);
                }

                element = element.Substring(1) + element.Substring(0, 1);

                index++;
            }

            output.Add(minValue);
            sum += minValue;
            minValue = int.MaxValue;
        }
    }

    static void MaxValue(List<string> input, List<int> output, ref int sum)
    {
        int maxValue = int.MinValue;

        for (int i = 0; i < input.Count; i++)
        {
            string element = input[i];

            byte index = 0;

            while (index <= element.Length)
            {
                if (int.Parse(element) > maxValue)
                {
                    maxValue = int.Parse(element);
                }

                element = element.Substring(1) + element.Substring(0, 1);

                index++;
            }

            output.Add(maxValue);
            sum += maxValue;
            maxValue = int.MinValue;
        }
    }

    static List<string> ReadLine()
    {
        List<string> readLine = Console.ReadLine()            
            .Split(' ')
            .ToList();

        return readLine;
    }
    
    static void PrintResult(List<int> output)
    {
        Console.WriteLine(string.Join(", ", output));
        Console.WriteLine(output.Sum());
    }
}