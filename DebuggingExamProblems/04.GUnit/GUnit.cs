using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class GUnit
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, HashSet<string>>> gUnits =
            new Dictionary<string, Dictionary<string, HashSet<string>>>();

        ReadLine(gUnits);

        PrintResilt(gUnits);
    }

    static void PrintResilt(Dictionary<string, Dictionary<string, HashSet<string>>> gUnits)
    {
        var classes = gUnits
            .OrderByDescending(x => x.Value.Values.Sum(u => u.Count))
            .ThenBy(m => m.Value.Count)
            .ThenBy(c => c.Key, StringComparer.Ordinal)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var c in classes)
        {
            Console.WriteLine(c.Key + ":");

            var methods = c.Value
                .OrderByDescending(m => m.Value.Count)
                .ThenBy(m => m.Key, StringComparer.Ordinal)
                .ToDictionary(m => m.Key, m => m.Value);

            foreach (var m in methods)
            {
                Console.WriteLine("##" + m.Key);

                var unitTests = m.Value
                    .OrderBy(u => u.Length)
                    .ThenBy(u => u, StringComparer.Ordinal)
                    .ToList();

                foreach (var u in unitTests)
                {
                    Console.WriteLine("####" + u);
                }
            }
        }
    }

    static void ReadLine(Dictionary<string, Dictionary<string, HashSet<string>>> gUnits)
    {
        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("It's testing time!"))
            {
                break;
            }

            Regex regex = new Regex(@"(?<class>^[A-Z][A-Za-z0-9]+) \| (?<method>[A-Z][A-Za-z0-9]+) \| (?<unit>[A-Z][A-Za-z0-9]+$)");

            Match matchLine = regex.Match(readLine);

            if (!matchLine.Success)
            {
                continue;
            }

            string className = matchLine.Groups["class"].Value;
            string methodName = matchLine.Groups["method"].Value;
            string unitTestName = matchLine.Groups["unit"].Value;

            if (!gUnits.ContainsKey(className))
            {
                gUnits.Add(className, new Dictionary<string, HashSet<string>>());
            }

            if (!gUnits[className].ContainsKey(methodName))
            {
                gUnits[className].Add(methodName, new HashSet<string>());
            }

            gUnits[className][methodName].Add(unitTestName);
        }
    }
}