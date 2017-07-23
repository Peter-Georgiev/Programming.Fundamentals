using System;
using System.Linq;
using System.Text.RegularExpressions;

class Happiness
{
    public string Emoticon { get; set; }

    public double HappinessIndex { get; set; }

    public int HappyCount { get; set; }

    public int SadCount { get; set; }
}

class HappinessIndex
{
    static void Main()
    {
        string readLine = Console.ReadLine();

        string pattern = 
            @"(?<happy>[:;][)\]}*D]|[(*c\[][:;]){1,2}|(?<sad>[:;D][(:\[{c]|[)\]][:;]){1,2}";
        MatchCollection regexHappySad = Regex.Matches(readLine, pattern);

        int happyCount = regexHappySad
            .Cast<Match>()
            .Where(x => x.Groups["happy"].Value != String.Empty)
            .Count();
        int sadCount = regexHappySad
            .Cast<Match>()
            .Where(x => x.Groups["sad"].Value != String.Empty)
            .Count();

        double happinessIndex = (double)happyCount / (double)sadCount;

        Happiness happiness = new Happiness()
        {
            Emoticon = GetEmoticon(happinessIndex),
            HappinessIndex = happinessIndex,
            HappyCount = happyCount,
            SadCount = sadCount
        };

        PrintHappinessIndex(happiness);
    }

    private static void PrintHappinessIndex(Happiness happiness)
    {
        Console.WriteLine($"Happiness index: {happiness.HappinessIndex:F2} {happiness.Emoticon}");
        Console.WriteLine($"[Happy count: {happiness.HappyCount}, Sad count: {happiness.SadCount}]");
    }

    static string GetEmoticon(double happinessIndex)
    {
        string emoticon = String.Empty;

        if (happinessIndex >= 2)
        {
            emoticon = ":D";
        }
        else if (happinessIndex > 1)
        {
            emoticon = ":)";
        }
        else if (happinessIndex.Equals(1))
        {
            emoticon = ":|";
        }
        else
        {
            emoticon = ":(";
        }

        return emoticon;
    }
}