using System;
using System.Linq;

class TextFilter
{
    static void Main()
    {
        string[] banWords = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        string text = Console.ReadLine();

        foreach (var banWord in banWords)
        {
            if (text.Contains(banWord))
            {
                text = text.Replace(banWord, new string('*', banWord.Length));
            }
        }

        Console.WriteLine(text);
    }
}