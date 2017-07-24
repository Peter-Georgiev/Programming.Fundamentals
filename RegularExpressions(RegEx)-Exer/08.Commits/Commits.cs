using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class GitHub
{
    public string CommitHash { get; set; }
    public string Message { get; set; }
    public int Addition { get; set; }
    public int Deletions { get; set; }
}

class Commits
{
    static void Main()
    {
        var github = new Dictionary<string, Dictionary<string, List<GitHub>>>();

        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("git push"))
            {
                break;
            }

            AddedCommits(github, readLine);
        }

        PrintCommits(github);
    }

    private static void AddedCommits(Dictionary<string, Dictionary<string, List<GitHub>>> github, string readLine)
    {
        string pattern = @"(?:https:)(\/)(?:\1github.com)\1(?<user>[A-Z-a-z0-9_]+)\1(?<repo>[A-Za-z-_]+)\1(?:commit)\1(?<hash>[a-f\d]{40}),(?<message>.*),(?<additions>[\d]+),(?<deletions>[\d]+)";

        Match regexInput = Regex.Match(readLine, pattern);

        string message = regexInput.Groups["message"].Value;
        bool hasNewLineInMessage = message.Contains("\\n") || message.Contains("\\r");

        if (regexInput.Length > 0 && !hasNewLineInMessage)
        {
            string user = regexInput.Groups["user"].Value;
            string repo = regexInput.Groups["repo"].Value;

            if (!github.ContainsKey(user))
            {
                github.Add(user, new Dictionary<string, List<GitHub>>());
            }

            if (!github[user].ContainsKey(repo))
            {
                github[user].Add(repo, new List<GitHub>());
            }

            GitHub newGitHub = new GitHub()
            {
                Message = message,
                CommitHash = regexInput.Groups["hash"].Value,
                Addition = int.Parse(regexInput.Groups["additions"].Value),
                Deletions = int.Parse(regexInput.Groups["deletions"].Value)
            };

            github[user][repo].Add(newGitHub);
        }
    }

    static void PrintCommits(Dictionary<string, Dictionary<string, List<GitHub>>> github)
    {
        var sortedName = github
            .OrderBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var kvpName in sortedName)
        {
            Console.WriteLine(kvpName.Key + ":");

            var sorterdRepos = kvpName.Value
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvpRepo in sorterdRepos)
            {
                Console.WriteLine("  " + kvpRepo.Key + ":");

                foreach (GitHub kvp in kvpRepo.Value)
                {
                    Console.WriteLine($"    commit {kvp.CommitHash}: {kvp.Message} " +
                        $"({kvp.Addition} additions, {kvp.Deletions} deletions)");
                }

                int totalAdditionsCount = kvpRepo.Value
                    .Sum(x => x.Addition);
                int totalDeletionsCount = kvpRepo.Value
                    .Sum(x => x.Deletions);

                Console.WriteLine($"    Total: {totalAdditionsCount} additions, " +
                    $"{totalDeletionsCount} deletions");
            }
        }
    }
}