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
        int secondsForEachStep = int.Parse(Console.ReadLine());

        int timeSeconds = (timesTokens[0] * 60 * 60) + (timesTokens[1] * 60) + timesTokens[2];
        long secondsToStep = (long)stepsHome * (long)secondsForEachStep + timeSeconds;

        long second = secondsToStep % 60;
        long min = (secondsToStep / 60) % 60;
        long hour = (secondsToStep / 60 / 60) % 24;

        Console.WriteLine($"Time Arrival: {hour:D2}:{min:D2}:{second:D2}");
    }
}