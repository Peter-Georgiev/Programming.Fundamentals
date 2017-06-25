using System;
using System.Collections.Generic;
using System.Linq;

class SocialMediaPosts
{
    static void Main()
    {
        var socialMedia = new Dictionary<string, Dictionary<string, List<string>>>();

        string readLine = Console.ReadLine();

        readLine = AddInSocialMediaPosts(socialMedia, readLine);

        PrintSocialMediaPosts(socialMedia);
    }

    private static string AddInSocialMediaPosts(Dictionary<string, Dictionary<string, List<string>>> socialMedia, string readLine)
    {
        while (!readLine.Equals("drop the media"))
        {
            string[] tokens = readLine.Split(' ').ToArray();
            string command = tokens[0];
            string postNamae = tokens[1];
            bool hasPostName = socialMedia.ContainsKey(postNamae);

            if (command.Equals("post"))
            {
                if (!hasPostName)
                {
                    socialMedia.Add(postNamae, new Dictionary<string, List<string>>());
                }
            }
            else if (command.Equals("like") && hasPostName)
            {
                if (!socialMedia[postNamae].ContainsKey(command))
                {
                    socialMedia[postNamae].Add(command, new List<string>() { command });
                }
                else
                {
                    socialMedia[postNamae][command].Add(command);
                }
            }
            else if (command.Equals("dislike") && hasPostName)
            {
                if (!socialMedia[postNamae].ContainsKey(command))
                {
                    socialMedia[postNamae].Add(command, new List<string>() { command });
                }
                else
                {
                    socialMedia[postNamae][command].Add(command);
                }
            }
            else if (command.Equals("comment") && hasPostName)
            {
                string commentatorName = tokens[2];
                byte spaces = 3;
                string content = readLine
                    .Substring(command.Length + postNamae.Length + commentatorName.Length + spaces);

                socialMedia[postNamae][commentatorName] = new List<string>() { content };
            }

            readLine = Console.ReadLine();
        }

        return readLine;
    }

    private static void PrintSocialMediaPosts(Dictionary<string, Dictionary<string, List<string>>> socialMedia)
    {
        foreach (var printSocialMedia in socialMedia)
        {
            string postName = printSocialMedia.Key;
            Console.WriteLine($"Post: {printSocialMedia.Key} | " +
                $"Likes: {CountLikesOrDislikes(socialMedia, postName, "like")} | " +
                $"Dislikes: {CountLikesOrDislikes(socialMedia, postName, "dislike")}");

            Console.WriteLine($"Comments:");
            byte none = 0;

            foreach (var printComment in printSocialMedia.Value)
            {
                bool hasDislikeAndLike =
                printComment.Key.Equals("like") || printComment.Key.Equals("dislike");


                if (!hasDislikeAndLike)
                {
                    Console.WriteLine($"*  {printComment.Key}: {string.Join("", printComment.Value)}");
                    none++;
                }
            }

            if (none.Equals(0))
            {
                Console.WriteLine("None");
            }
        }
    }

    private static int CountLikesOrDislikes
        (Dictionary<string, Dictionary<string, List<string>>> socialMedia, string postName, string disOrLike)
    {
        int countDisOrLike = 0;

        foreach (var countDislikeOrLike in socialMedia)
        {
            foreach (var findDisOrLike in countDislikeOrLike.Value)
            {
                bool hasEqualsPostNameAndDisOrLike =
                    countDislikeOrLike.Key.Equals(postName) && findDisOrLike.Key.Equals(disOrLike);

                if (hasEqualsPostNameAndDisOrLike)
                {
                    foreach (var count in findDisOrLike.Value)
                    {
                        countDisOrLike++;
                    }                    
                }
            }          
        }

        return countDisOrLike;
    }
}