using System;
using System.Linq;

class WordInPlural
{
    static void Main()
    {
        string word = Console.ReadLine();

        string result;
        string[] nounEs = { "o", "ch", "s", "sh", "x", "z" };
        bool isNounEs = nounEs.Any(x => word.EndsWith(x));
        bool isNounY = word.EndsWith("y");

        if (isNounEs)
        {
            result = word + "es";
        }
        else if (isNounY)
        {
            word = word.Remove(word.Length - 1);
            result = word + "ies";
        }
        else
        {
            result = word + "s";
        }

        Console.WriteLine(result);
    }
}