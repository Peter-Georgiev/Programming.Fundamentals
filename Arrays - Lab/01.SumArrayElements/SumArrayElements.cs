using System;

class SumArrayElements
{
    static void Main()
    {
        int[] readLine = ReadLine();

        PrintSumNumbers(readLine);
    }

    static int[] ReadLine()
    {
        byte n = byte.Parse(Console.ReadLine());

        int[] readLine = new int[n];

        for (int i = 0; i < readLine.Length; i++)
        {
            readLine[i] = int.Parse(Console.ReadLine());
        }

        return readLine;
    }

    static void PrintSumNumbers(int[] readLine)
    {
        long sum = 0;

        for (int i = 0; i < readLine.Length; i++)
        {
            sum += readLine[i];
        }

        Console.WriteLine(sum);
    }
}