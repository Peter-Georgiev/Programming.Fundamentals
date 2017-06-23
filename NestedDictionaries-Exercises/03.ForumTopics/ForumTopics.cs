using System;
using System.Collections.Generic;
using System.Linq;

class ForumTopics
{
    static void Main()
    {
        var forumBook = new Dictionary<string, HashSet<string>>();

        string readLine = Console.ReadLine();

        AddForumBook(forumBook, readLine);

        readLine = Console.ReadLine();

        PrintResult(forumBook, readLine);
    }

    private static void PrintResult(Dictionary<string, HashSet<string>> forumBook, string readLine)
    {
        string[] tokens = readLine
                        .Split(" ->,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

        var containsTopics = new Dictionary<string, int>();

        foreach (var printForumBook in forumBook)
        {
            bool hasContain = false;

            foreach (var findTags in tokens)
            {
                if (printForumBook.Value.Contains(findTags))
                {
                    hasContain = true;
                }
                else
                {
                    hasContain = false;
                    break;
                }
            }

            if (hasContain)
            {
                Console.WriteLine($"{printForumBook.Key} | #{string.Join(", #", printForumBook.Value)}");
            }
        }
    }

    private static void AddForumBook(Dictionary<string, HashSet<string>> forumBook, string readLine)
    {
        while (!readLine.Equals("filter"))
        {
            string[] tokens = readLine
                .Split(" ->,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string topic = tokens[0];

            if (!forumBook.ContainsKey(topic))
            {
                forumBook.Add(topic, new HashSet<string>());
            }

            for (int i = 1; i < tokens.Length; i++)
            {
                forumBook[topic].Add(tokens[i]);
            }

            readLine = Console.ReadLine();
        }
    }
}