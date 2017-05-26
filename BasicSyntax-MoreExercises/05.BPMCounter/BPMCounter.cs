using System;

class BPMCounter
{
    static void Main()
    {
        int beatsPerMinute = int.Parse(Console.ReadLine());
        int beatsCount = int.Parse(Console.ReadLine());

        double time = ((double)beatsCount / beatsPerMinute) * 60d;
        int mins = (int)time / 60;
        double secs = (int)time % 60;
        double bars = Math.Round((double)beatsCount / 4, 1);

        Console.WriteLine($"{bars} bars - {mins}m {secs}s");
    }
}