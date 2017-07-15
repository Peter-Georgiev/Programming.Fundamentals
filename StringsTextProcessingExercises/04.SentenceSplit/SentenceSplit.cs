using System;
using System.Collections.Generic;
using System.Linq;

class SentenceSplit
{
    static void Main()
    {
        string readLine = Console.ReadLine();
        string readSplitCommand = Console.ReadLine();

        int splitLenght = readSplitCommand.Length;

        List<string> split = new List<string>();

        int count = 0;
        string element = String.Empty;
        int tempSkip = 0;
        for (int i = 0; i < readLine.Length - splitLenght; i++)
        {
            bool hasSplit = 
                string.Join("", readLine.Skip(i).Take(splitLenght)) == readSplitCommand;

            if (hasSplit)
            {
                element = string.Join("", readLine.Skip(tempSkip).Take(i));
                tempSkip += element.Length + splitLenght;
                split.Add(element);                
                count = i;
            }
        }

        element = string.Join("", readLine.Skip(count + splitLenght));
        split.Add(element);

        Console.WriteLine("[" + string.Join(", ", split) + "]");
    }
}