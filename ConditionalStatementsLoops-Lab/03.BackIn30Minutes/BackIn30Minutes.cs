using System;

class BackIn30Minutes
{
    static void Main()
    {
        int hour = int.Parse(Console.ReadLine());
        int minute = int.Parse(Console.ReadLine());

        if (minute + 30 >= 59)
        {
            hour++;
            minute = 30 - (60 - minute);
        }
        else
        {
            minute += 30;
        }
        if (hour > 23)
        {
            hour -= 24;
        }

        Console.WriteLine($"{hour}:{minute:D2}");
    }
}