using System;

class Transport
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        double courses = Math.Ceiling((double)n / (4 + 8 + 12));
        Console.WriteLine(courses);
    }
}