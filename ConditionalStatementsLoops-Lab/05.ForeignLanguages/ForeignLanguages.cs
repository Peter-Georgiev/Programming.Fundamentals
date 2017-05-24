using System;

class ForeignLanguages
{
    static void Main()
    {
        string speak = Console.ReadLine();

        string message;

        switch (speak)
        {
            case "USA":
            case "England":
                message = "English";
                break;
            case "Spain":
            case "Argentina":
            case "Mexico":
                message = "Spanish";
                break;
            default:
                message = "unknown";
                break;
        }
        Console.WriteLine(message);
    }
}