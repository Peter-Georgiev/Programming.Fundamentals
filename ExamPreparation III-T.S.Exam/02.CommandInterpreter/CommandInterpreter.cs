using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class CommandInterpreter
{
    static void Main()
    {
        List<string> input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        string[] result = new string[input.Count];
        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("end"))
            {
                break;
            }

            Match regex = Regex.Match(command, @"(?<1>reverse(?:\s+from\s+-?\d+\s+count\s+-?\d+))|(?<2>sort(?:\s+from\s+-?\d+\s+count\s+-?\d+))|(?<3>rollLeft(?:\s+-?\d+\s+times))|(?<4>rollRight(?:\s+-?\d+\s+times))");

            if (!regex.Success)
            {
                continue;
            }

            string[] tokens = new string[0];
            for (int i = 0; i < regex.Groups.Count; i++)
            {
                if (regex.Groups[$"{i}"].Length > 0)
                {
                    tokens = tokens = regex.Groups[$"{i}"].Value.ToLower()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                }
            }

            if (tokens[0] == "reverse")
            {
                int fromStart = int.Parse(tokens[2]);
                int count = int.Parse(tokens[4]);

                if ((fromStart < 0 || fromStart >= input.Count) ||
                    (fromStart + count < 0 || fromStart + count >= input.Count))
                {
                    Console.WriteLine("Invalid input parameters.");
                    continue;
                }

                var tempRevers = input
                    .Skip(fromStart)
                    .Take(count)
                    .Reverse()
                    .ToList();

                input.RemoveRange(fromStart, count);
                input.InsertRange(fromStart, tempRevers);

                for (int i = 0; i < input.Count; i++)
                {
                    result[i] = input[i];
                }
            }
            else if (tokens[0] == "sort")
            {
                int fromStart = int.Parse(tokens[2]);
                int count = int.Parse(tokens[4]);

                if ((fromStart < 0 || fromStart >= input.Count) ||
                    (fromStart + count < 0 || fromStart + count >= input.Count))
                {
                    Console.WriteLine("Invalid input parameters.");
                    continue;
                }

                var tempSorted = input
                   .Skip(fromStart)
                   .Take(count)
                   .OrderBy(x => x)
                   .ToList();

                input.RemoveRange(fromStart, count);
                input.InsertRange(fromStart, tempSorted);
                for (int i = 0; i < input.Count; i++)
                {
                    result[i] = input[i];
                }
            }
            else if (tokens[0] == "rollleft")
            {
                int count = int.Parse(tokens[1]);

                for (int oldIndex = 0; oldIndex < input.Count; oldIndex++)
                {
                    int newIndex = oldIndex + (-count);
                    newIndex = newIndex % input.Count;

                    if (newIndex < 0)
                    {
                        newIndex += input.Count;
                    }

                    result[newIndex] = input[oldIndex];
                }
            }
            else if (tokens[0] == "rollright")
            {
                int count = int.Parse(tokens[1]);
                
                for (int oldIndex = 0; oldIndex < input.Count; oldIndex++)
                {
                    int newIndex = oldIndex + count;
                    newIndex = newIndex % input.Count;

                    if (newIndex < 0)
                    {
                        newIndex += input.Count;
                    }

                    result[newIndex] = input[oldIndex];
                }
            }
        }

        Console.WriteLine("[" + string.Join(", ", result) + "]");
    }
}