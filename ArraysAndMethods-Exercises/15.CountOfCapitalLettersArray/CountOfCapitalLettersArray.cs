using System;
using System.Linq;

class CountOfCapitalLettersArray
{
    static void Main()
    {
        string[] arrayOfString = Console.ReadLine().Split(' ').ToArray();
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        byte count = 0;
        for (int i = 0; i < arrayOfString.Length; i++)
        {
            for (int j = 0; j < letters.Length; j++)
            {
                if (arrayOfString[i] == Convert.ToString(letters[j]))
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }
}