using System;

class ChooseDrink
{
    static void Main()
    {
        string person = Console.ReadLine();

        string messages;
        switch (person)
        {
            case "Athlete":
                messages = "Water";
                break;
            case "Businessman":
            case "Businesswoman":
                messages = "Coffee";
                break;
            case "SoftUni Student":
                messages = "Beer";
                break;
            default:
                messages = "Tea";
                break;
        }

        Console.WriteLine(messages);
    }
}