using System;
using System.Collections.Generic;
using System.Linq;

class Shellbound
{
    static void Main()
    {
        Dictionary<string, List<long>> shellsNameSize =
            new Dictionary<string, List<long>>();

        string readLine = Console.ReadLine();

        GetInputShellsNameSize(shellsNameSize, readLine);

        PrintShellsNameSize(shellsNameSize);

    }

    private static void GetInputShellsNameSize(Dictionary<string, List<long>> shellsNameSize, string readLine)
    {
        while (!readLine.Equals("Aggregate"))
        {
            string[] tokens = readLine.Split(' ').ToArray();
            string name = tokens[0];
            long size = long.Parse(tokens[1]);

            if (!shellsNameSize.ContainsKey(name))
            {
                shellsNameSize.Add(name, new List<long>());
                shellsNameSize[name].Add(size);
            }
            else
            {
                if (!shellsNameSize[name].Contains(size))
                {
                    shellsNameSize[name].Add(size);
                }
            }

            readLine = Console.ReadLine();
        }
    }

    private static void PrintShellsNameSize(Dictionary<string, List<long>> shellsNameSize)
    {
        foreach (var printShellsNameSize in shellsNameSize)
        {
            Console.Write($"{printShellsNameSize.Key} -> ");

            var sum = printShellsNameSize.Value.Sum() -
                (printShellsNameSize.Value.Sum() / printShellsNameSize.Value.Count);

            Console.Write(string.Join(", ", printShellsNameSize.Value));

            Console.WriteLine($" ({sum})");
        }
    }
}