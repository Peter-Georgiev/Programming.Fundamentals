using System;
using System.Linq;

class Altitude
{
    static void Main()
    {
        string[] inputCommand = Console.ReadLine().Split(' ').ToArray();

        double altitude = double.Parse(inputCommand[0]);

        for (int i = 1; i < inputCommand.Length - 1; i += 2)
        {
            if (inputCommand[i].Equals("up"))
            {
                altitude += double.Parse(inputCommand[i + 1]);
            }
            else if (inputCommand[i].Equals("down"))
            {
                altitude -= double.Parse(inputCommand[i + 1]);
            }

            if (altitude <= 0)
            {
                break;
            }
        }

        if (altitude > 0)
        {
            Console.WriteLine($"got through safely. current altitude: {altitude}m");
        }
        else
        {
            Console.WriteLine($"crashed");
        }
    }
}