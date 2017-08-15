using System;
using System.Linq;

class SinoTheWalker
{
    static void Main()
    {
        int[] timesTokens = Console.ReadLine()
            .Split(':')
            .Select(int.Parse)
            .ToArray();
        int stepsHome = int.Parse(Console.ReadLine());
        long secondsForEachStep = long.Parse(Console.ReadLine());


        int timeSeconds = (timesTokens[0] * 60 * 60) +
            (timesTokens[1] * 60) + timesTokens[2];
        long secondsToStep = stepsHome * secondsForEachStep + timeSeconds;

        long second = secondsToStep % 60;
        long minute = (secondsToStep / 60) % 60;
        long hour = (secondsToStep / 60 / 60) % 24;

        Console.WriteLine($"Time Arrival: {hour:D2}:{minute:D2}:{second:D2}");
    }
}