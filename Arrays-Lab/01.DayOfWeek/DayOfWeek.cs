using System;

class DayOfWeek
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());

        string[] dayNames = new string[] { "Monday", "Tuesday", "Wednesday",
            "Thursday", "Friday", "Saturday", "Sunday" };
        string deyWeek = "Invalid Day!";

        for (int i = 0; i < dayNames.Length; i++)
        {
            if (day - 1 == i)
            {
                deyWeek = dayNames[i];
            }
        }

        Console.WriteLine(deyWeek);
    }
}