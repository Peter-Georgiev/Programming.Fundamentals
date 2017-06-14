using System;

class MinMethod
{
    static void Main()
    {
        int[] readLine = ReadLine();

        int minInteger = GetMin(readLine);

        PrintMinInteger(minInteger);
    }

    static int[] ReadLine()
    {
        int[] readLine = new int[3];

        for (int i = 0; i < readLine.Length; i++)
        {
            readLine[i] = int.Parse(Console.ReadLine());
        }

        return readLine;
    }

    static int GetMin(int[] readLine)
    {
        int minInteger = int.MaxValue;

        for (int i = 0; i < readLine.Length; i++)
        {
            if (readLine[i] < minInteger)
            {
                minInteger = readLine[i];
            }
        }

        return minInteger;
    }

    static void PrintMinInteger(int minInteger)
    {
        Console.WriteLine(minInteger);
    }
}