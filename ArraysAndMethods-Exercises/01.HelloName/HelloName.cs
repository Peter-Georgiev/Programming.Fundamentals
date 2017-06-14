using System;

class HelloName
{
    static void Main()
    {
        string readLine = ReadLine();
        PrintHelloName(readLine);
    }

    static string ReadLine()
    {
        string readLine = Console.ReadLine();
        return readLine;
    }

    static void PrintHelloName(string readLine)
    {
        Console.WriteLine($"Hello, {readLine}!");
    }
}