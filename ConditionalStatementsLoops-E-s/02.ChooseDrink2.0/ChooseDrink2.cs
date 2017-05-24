using System;

class ChooseDrink2
{
    static void Main()
    {
        string person = Console.ReadLine();
        int quantity = int.Parse(Console.ReadLine());

        double result;
        string messages;
        if (person.Equals("Athlete") && quantity == 1)
        {
            messages = "Water";
        }
        else if (person.Equals("SoftUni Student") && quantity == 8)
        {
            result = quantity * 1.70d;
            messages = $"The {person} has to pay {result:F2}";
        }
        else
        {
            switch (person)
            {
                case "Athlete":
                    result = quantity * 0.70d;
                    messages = $"The {person} has to pay {result:F2}.";
                    break;
                case "Businessman":
                case "Businesswoman":
                    result = quantity * 1.00d;
                    messages = $"The {person} has to pay {result:F2}.";
                    break;
                case "SoftUni Student":
                    result = quantity * 1.70d;
                    messages = $"The {person} has to pay {result:F2}.";
                    break;
                default:
                    result = quantity * 1.20d;
                    messages = $"The {person} has to pay {result:F2}.";
                    break;
            }
        }       

        Console.WriteLine(messages);
    }
}