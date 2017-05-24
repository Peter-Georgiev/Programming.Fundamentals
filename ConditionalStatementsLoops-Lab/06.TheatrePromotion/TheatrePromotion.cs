using System;

class TheatrePromotion
{
    static void Main()
    {
        string day = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        string message = "Error!";

        if (0 <= age && age <= 18)
        {
            switch (day)
            {
                case "Weekday":
                    message = "12$";
                    break;
                case "Weekend":
                    message = "15$";
                    break;
                case "Holiday":
                    message = "5$";
                    break;
            }
        }
        else if (18 < age && age <= 64)
        {
            switch (day)
            {
                case "Weekday":
                    message = "18$";
                    break;
                case "Weekend":
                    message = "20$";
                    break;
                case "Holiday":
                    message = "12$";
                    break;
            }
        }
        else if (64 < age && age <= 122)
        {
            switch (day)
            {
                case "Weekday":
                    message = "12$";
                    break;
                case "Weekend":
                    message = "15$";
                    break;
                case "Holiday":
                    message = "10$";
                    break;
            }
        }

        Console.WriteLine(message);

    }
}