using System;

class CountSubstringOccurrences
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = Console.ReadLine();

        byte count = 0;
        int index = input.ToLower().IndexOf(pattern.ToLower());

        while (index != -1)
        {
            count++;
            index = input.ToLower().IndexOf(pattern.ToLower(), index + 1);
        }

        Console.WriteLine(count);
    }
}