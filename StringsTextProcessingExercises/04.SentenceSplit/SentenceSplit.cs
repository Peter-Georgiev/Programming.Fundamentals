using System;
using System.Linq;

class SentenceSplit
{
    static void Main()
    {
        string readLine = Console.ReadLine();
        string readSplitCommand = Console.ReadLine();

        string[] split = new string[] { readSplitCommand };
        
        string[] elements = readLine
            .Split(split, StringSplitOptions.None)
            .ToArray();
        
        Console.WriteLine("[" + string.Join(", ", elements) + "]");
    }
}