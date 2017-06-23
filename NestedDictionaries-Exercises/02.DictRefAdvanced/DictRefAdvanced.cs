using System;
using System.Collections.Generic;
using System.Linq;

class DictRefAdvanced
{
    static void Main()
    {
        Dictionary<string, List<int>> dictRefAdvanced =
            new Dictionary<string, List<int>>();

        string readLine = Console.ReadLine();

        GetInputDictRefAdvanced(dictRefAdvanced, readLine);

        PrintDictRefAdvanced(dictRefAdvanced);
    }

    private static void GetInputDictRefAdvanced(Dictionary<string, List<int>> dictRefAdvanced, string readLine)
    {
        while (!readLine.Equals("end"))
        {
            string[] tokens = readLine
                .Split("->, ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string firstName = tokens[0];
            string secondName = string.Empty;
            List<int> numbers = new List<int>();

            for (int i = 0; i < tokens.Length; i++)
            {
                if (int.TryParse(tokens[i], out int n))
                {
                    numbers.Add(n);
                }
                else if (i == 1)
                {
                    secondName = tokens[1];
                }
            }

            bool isSecondName = !secondName.Equals(string.Empty) && dictRefAdvanced.ContainsKey(secondName);

            if (!dictRefAdvanced.ContainsKey(firstName))
            {
                if (isSecondName)
                {
                    dictRefAdvanced.Add(firstName, new List<int>());
                    dictRefAdvanced[firstName].AddRange(dictRefAdvanced[secondName]);
                }
                else if (numbers.Count > 0)
                {
                    dictRefAdvanced.Add(firstName, new List<int>());
                    dictRefAdvanced[firstName].AddRange(numbers);
                }
            }
            else
            {
                if (isSecondName)
                {                   
                    dictRefAdvanced[firstName].AddRange(dictRefAdvanced[secondName]);
                }
                else if (numbers.Count > 0)
                {
                    dictRefAdvanced[firstName].AddRange(numbers);
                }
            }

            readLine = Console.ReadLine();
        }
    }

    private static void PrintDictRefAdvanced(Dictionary<string, List<int>> dictRefAdvanced)
    {
        foreach (var printDictRefAdvanced in dictRefAdvanced)
        {
            Console.Write($"{printDictRefAdvanced.Key} === ");

            Console.WriteLine(string.Join(", ", printDictRefAdvanced.Value));
        }
    }
}