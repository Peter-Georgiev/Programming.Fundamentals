using System;

class MagicLetter
{
    static void Main()
    {
        char firstLetter = char.Parse(Console.ReadLine());
        char secondLetter = char.Parse(Console.ReadLine());
        char thirdLetter = char.Parse(Console.ReadLine());

        for (int count1 = firstLetter; count1 <= secondLetter; count1++)
        {
            for (int count2 = firstLetter; count2 <= secondLetter; count2++)
            {
                for (int count3 = firstLetter; count3 <= secondLetter; count3++)
                {
                    if (!count1.Equals(thirdLetter) && !count2.Equals(thirdLetter) && !count3.Equals(thirdLetter))
                    {
                        Console.Write($"{(char)count1}{(char)count2}{(char)count3} ");
                    }
                }
            }
        }
        Console.WriteLine();
    }
}