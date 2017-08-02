using System;

class DiamondProblem
{
    static void Main()
    {
        string readLine = Console.ReadLine();

        bool isFound = false;
        int leftIndex = -1;
        int rightIndex = -1;

        while ((leftIndex = readLine.IndexOf('<', leftIndex + 1)) > -1
            && (rightIndex = readLine.IndexOf('>', leftIndex + 1)) > -1)
        {
            string diamondContent =
                readLine.Substring(leftIndex + 1, rightIndex - leftIndex - 1);

            int carats = FindCarats(diamondContent);

            Console.WriteLine("Found {0} carat diamond", carats);
            isFound = true;
        }

        if (!isFound)
        {
            Console.WriteLine("Better luck next time");
        }
    }

    private static int FindCarats(string diamondContent)
    {
        int carats = 0;

        foreach (char @char in diamondContent)
        {
            if (char.IsDigit(@char))
            {
                carats += int.Parse(@char.ToString());
            }
        }
        return carats;
    }
}