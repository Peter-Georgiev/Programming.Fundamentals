using System;
using System.Linq;

class RandomizeWords
{
    static void Main()
    {

        var word = Console.ReadLine()
            .Split(' ')
            .ToArray();

        var random = new Random();

        for (int i = 0; i < word.Length; i++)
        {
            var currentWord = word[i];
            var randomPosition = random.Next(0, word.Length);
            var temporaryWord = word[randomPosition];
            word[randomPosition] = currentWord;
            word[i] = temporaryWord;
        }

        foreach (var print in word)
        {
            Console.WriteLine(print);
        }
    }
}