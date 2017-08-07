using System;
using System.Text;
using System.Text.RegularExpressions;

class MelrahShake
{
    static void Main()
    {
        string readLine = Console.ReadLine();
        string inputPattern = Console.ReadLine();

        StringBuilder result = new StringBuilder();
        result.Append(readLine);
        StringBuilder pattern = new StringBuilder();
        pattern.Append(inputPattern);

        while(true)
        {

            Regex regex = new Regex(Regex.Escape($"{pattern}"));
            MatchCollection newMatch = regex.Matches(result.ToString());

            if (newMatch.Count < 2 || pattern.ToString() == String.Empty)
            {
                Console.WriteLine("No shake.");
                break;
            }

            Console.WriteLine("Shaked it.");

            int firstIndex = result.ToString().IndexOf(pattern.ToString());
            int lastIndex = result.ToString().LastIndexOf(pattern.ToString());

            result = result
                .Remove(lastIndex, pattern.Length)
                .Remove(firstIndex, pattern.Length);

            string tempPattern = pattern.ToString();
            pattern.Clear();
            pattern.Append(tempPattern.Remove(tempPattern.Length / 2, 1));
        }

        Console.WriteLine(result);
    }
}