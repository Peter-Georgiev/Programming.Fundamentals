using System;
using System.Collections.Generic;
using System.Linq;

class JapaneseRoulette
{
    static void Main()
    {
        byte[] cylinderLine = ReadLine().Select(byte.Parse).ToArray();
        string[] commandLine = ReadLine();
        
        PrintResult(GetRoulette(cylinderLine, commandLine));
    }

    static string GetRoulette(byte[] cylinderLine, string[] commandLine)
    {
        bool isDead = false;
        int currentIndex = 0;
        int cylinderIndex = 0;
        string message = string.Empty;

        for (int i = 0; i < cylinderLine.Length; i++)
        {
            if (cylinderLine[i].Equals(1))
            {
                cylinderIndex = i;
            }
        }

        for (int i = 0; i < commandLine.Length; i++)
        {
            string[] powerAndDirection = commandLine[i].Split(',').ToArray();
            int power = int.Parse(powerAndDirection[0]);
            string direction = powerAndDirection[1];
            isDead = false;

            switch (direction)
            {
                case "Right":
                    currentIndex = (cylinderIndex + power) % cylinderLine.Length;
                    cylinderIndex = currentIndex;
                    break;
                case "Left":
                    currentIndex = (cylinderIndex - power) % cylinderLine.Length;
                    if (currentIndex < 0)
                    {
                        currentIndex += cylinderLine.Length;
                    }
                    cylinderIndex = currentIndex;
                    break;
            }

            if (currentIndex == 2)
            {
                message = $"Game over! Player {i} is dead.";
                isDead = true;
                break;
            }

            cylinderIndex++;
        }

        if (!isDead)
        {
            message = $"Everybody got lucky!";
        }

        return message;
    }

    static void PrintResult(string message)
    {
        Console.WriteLine(message);
    }

    static string[] ReadLine()
    {
        string[] readLine = Console.ReadLine()
            .Split(' ')
            .ToArray();

        return readLine;
    }
}