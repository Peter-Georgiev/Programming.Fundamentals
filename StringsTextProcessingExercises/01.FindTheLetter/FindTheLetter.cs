using System;
using System.Linq;

class FindTheLetter
{
    static void Main()
    {
        char[] readLineTokens = Console.ReadLine()
            .Select(x => x)
            .ToArray();
        string[] commandTokens = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        int result = 0;
        int countChar = 0;

        for (int i = 0; i < readLineTokens.Length; i++)
        {
            if (readLineTokens[i].Equals(Convert.ToChar(commandTokens[0])))
            {
                countChar++;
                if (countChar.Equals(int.Parse(commandTokens[1])))
                {
                    result = i;
                    break;
                }
            }
        }

        if (countChar.Equals(int.Parse(commandTokens[1])))
        {
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Find the letter yourself!");
        }
    }
}