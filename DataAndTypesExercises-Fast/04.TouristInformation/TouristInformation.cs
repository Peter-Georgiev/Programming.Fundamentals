using System;

class TouristInformation
{
    static void Main()
    {
        string namesType= Console.ReadLine();
        float convert = float.Parse(Console.ReadLine());

        string message = string.Empty;

        switch (namesType)
        {
            case "miles":
                message = $"{convert} miles = {convert * 1.6:F2} kilometers";
                break;
            case "inches":
                message = $"{convert} inches = {convert * 2.54:F2} centimeters";
                break;
            case "feet":
                message = $"{convert} feet = {convert * 30:F2} centimeters";
                break;
            case "yards":
                message = $"{convert} yards = {convert * 1.6:F2} meters";
                break;
            case "gallons":
                message = $"{convert} gallons = {convert * 3.8:F2} liters";
                break;
        }

        Console.WriteLine(message);
    }
}