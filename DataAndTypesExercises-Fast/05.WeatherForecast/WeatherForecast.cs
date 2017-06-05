using System;

class WeatherForecast
{
    static void Main()
    {
        try
        {
            long n = long.Parse(Console.ReadLine());

            string message = string.Empty;

            if (sbyte.MinValue <= n && n <= sbyte.MaxValue || byte.MinValue <= n && n <= byte.MaxValue)
            {
                message = "Sunny";
            }
            else if (int.MinValue <= n && n <= int.MaxValue)
            {
                message = "Cloudy";
            }
            else if (long.MinValue <= n && n <= long.MaxValue)
            {
                message = "Windy";
            }

            Console.WriteLine(message);
        }
        catch (Exception)
        {
            Console.WriteLine("Rainy");
        }        
    }
}