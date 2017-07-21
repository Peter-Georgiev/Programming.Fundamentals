using System;
using System.Collections.Generic;

class Nilapdromes
{
    static void Main()
    {
        List<string> input = new List<string>();

        ReadLine(input);

        FindNilapdromes(input);
    }

    static void FindNilapdromes(List<string> input)
    {
        for (int i = 0; i < input.Count; i++)
        {
            string borderLeft = input[i].Substring(0, input[i].Length / 2);
            string borderRight = String.Empty;

            if (input[i].Length % 2 == 0)
            {
                borderRight = input[i].Substring(
                    borderLeft.Length, input[i].Length - borderLeft.Length);
            }
            else
            {
                borderRight = input[i].Substring(
                    borderLeft.Length + 1, input[i].Length - borderLeft.Length - 1);
            }

            string border = String.Empty;

            while (true)
            {
                if (borderLeft == borderRight)
                {
                    border = borderLeft;
                    break;
                }
                else
                {
                    borderLeft = borderLeft.Substring(0, borderLeft.Length - 1);
                    borderRight = borderRight.Substring(1, borderRight.Length - 1);
                }
            }

            if (!border.Equals(String.Empty))
            {
                string core = input[i]
                    .Remove(input[i].Length - border.Length, border.Length)
                    .Remove(0, border.Length)
                    .Trim();

                PrintNalapdromes(border, core);
            }
        }
    }

    static void PrintNalapdromes(string border, string core)
    {
        if (!core.Equals(String.Empty))
        {
            string nilapdrome = core + border + core;

            Console.WriteLine(nilapdrome);
        }
    }

    static void ReadLine(List<string> input)
    {
        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("end"))
            {
                break;
            }

            input.Add(readLine.Trim());
        }
    }
}