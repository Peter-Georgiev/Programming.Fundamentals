using System;
using System.Linq;

class BallisticsTraining
{
    static void Main()
    {
        int[] coordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        string[] commands = Console.ReadLine().Split(' ').ToArray();
        int[] result = new int[2];

        for (int i = 0; i < commands.Length - 1; i += 2)
        {
            if (commands[i].Equals("right"))
            {
                result[0] += int.Parse(commands[i + 1]);
            }
            else if (commands[i].Equals("down"))
            {
                result[1] -= int.Parse(commands[i + 1]);
            }
            else if (commands[i].Equals("left"))
            {
                result[0] -= int.Parse(commands[i + 1]);
            }
            else if (commands[i].Equals("up"))
            {
                result[1] += int.Parse(commands[i + 1]);
            }
        }

        if (result[0] == coordinates[0] && result[1] == coordinates[1])
        {
            Console.WriteLine($"firing at [{result[0]}, {result[1]}]");
            Console.WriteLine($"got 'em!");
        }
        else
        {
            Console.WriteLine($"firing at [{result[0]}, {result[1]}]");
            Console.WriteLine($"better luck next time...");
        }
    }
}