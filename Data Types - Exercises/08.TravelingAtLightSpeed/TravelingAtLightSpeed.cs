using System;
using System.Globalization;

class TravelingAtLightSpeed
{
    static void Main()
    {
        decimal lightYears = decimal.Parse(Console.ReadLine());

        decimal total = (9450000000000M / 300000M) * lightYears;

        TimeSpan duration = TimeSpan.FromSeconds(Convert.ToDouble(total));
        string convert = String.Format(CultureInfo.CurrentCulture,
            $"{duration.Days / 7} weeks\n{duration.Days % 7} days\n" +
            $"{duration.Hours} hours\n{duration.Minutes} minutes\n{duration.Seconds} seconds");

        Console.WriteLine(convert);

    }
}