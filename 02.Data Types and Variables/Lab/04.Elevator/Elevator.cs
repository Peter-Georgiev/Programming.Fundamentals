using System;

class Elevator
{
    static void Main()
    {
        int peopleN = int.Parse(Console.ReadLine());
        int capacityP = int.Parse(Console.ReadLine());

        int courses = (int)Math.Ceiling((double)peopleN / capacityP);
        Console.WriteLine(courses);
    }
}