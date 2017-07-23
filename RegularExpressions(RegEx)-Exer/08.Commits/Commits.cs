using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class GitHub
{
    public string Username { get; set; }
    public string RepositoryName { get; set; }
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
        string pattern = @"^(?:https:)(\/)(?:\1github.com)\1(?<user>[\w-]+)\1(?<repo>[A-Za-z-_]+)\1(?:commit)\1(?<hash>[A-Fa-f\d]{40}),(?<message>.+),(?<additions>[\d]+),(?<deletions>[\d]+)$";

        Match regexInput = Regex.Match(readLine, pattern);

        string message = regexInput.Groups["message"].Value;
        bool hasNewLineInMessage = message.Contains("\\n");

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
                Username = user,
                RepositoryName = repo,
                CommitHash = regexInput.Groups["hash"].Value,
                Message = message,
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

            var repos = kvpName.Value
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            int totalAdditionsCount = 0;
            int totalDeletionsCount = 0;

            foreach (var kvpRepo in repos)
            {
                Console.WriteLine("  " + kvpRepo.Key + ":");

                foreach (var kvp in kvpRepo.Value)
                {
                    Console.WriteLine($"    commit {kvp.CommitHash}: {kvp.Message} ({kvp.Addition} additions, {kvp.Deletions} deletions)");
                }

                totalAdditionsCount = kvpRepo.Value
                    .Select(x => x.Addition)
                    .ToList()
                    .Sum();
                totalDeletionsCount = kvpRepo.Value
                    .Select(x => x.Deletions)
                    .ToList()
                    .Sum();

            }

            Console.WriteLine($"    Total: {totalAdditionsCount} additions, " +
                $"{totalDeletionsCount} deletions");
        }
    }
}