using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class MergeFiles
{
    static void Main()
    {
        string[] inputOne = File.ReadAllText("Input1.txt")
            .Split($" { Environment.NewLine} "
            .ToCharArray(),
            StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string[] inputTwo = File.ReadAllText("Input2.txt")
            .Split($" { Environment.NewLine} "
            .ToCharArray(),
            StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string[] output = inputOne.Concat(inputTwo)
            .OrderBy(x => x)
            .ToArray();

        File.WriteAllLines("Output.txt", output);
    }
}