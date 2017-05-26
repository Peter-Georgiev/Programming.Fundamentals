using System;

class Transport
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int capacity = int.Parse(Console.ReadLine());

        int courses = (int)Math.Ceiling((double)n / capacity);
        Console.WriteLine(courses);
    }
}