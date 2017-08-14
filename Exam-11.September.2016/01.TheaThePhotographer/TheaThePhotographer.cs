using System;

class TheaThePhotographer
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int ft = int.Parse(Console.ReadLine());
        int ff = int.Parse(Console.ReadLine());
        int ut = int.Parse(Console.ReadLine());

        decimal useful = Math.Ceiling(n * (ff / 100m));
        long totalTime = ((long)n * ft) + ((long)useful * ut);

        TimeSpan t = TimeSpan.FromSeconds(totalTime);

        string result = string.Format("{0}:{1:D2}:{2:D2}:{3:D2}",
            t.Days,
            t.Hours,
            t.Minutes,
            t.Seconds);

        Console.WriteLine(result);
    }
}