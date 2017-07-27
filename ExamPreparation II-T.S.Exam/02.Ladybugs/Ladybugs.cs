using System;
using System.Linq;
using System.Text.RegularExpressions;

class Ladybugs
{
    static void Main()
    {
        int[] sizeFilds = new int[int.Parse(Console.ReadLine())];
        int[] indexes = Regex.Split(Console.ReadLine(), @"\s+")
            .Select(x => x.Trim())
            .Select(int.Parse)
            .Where(x => x >= 0 && x <= sizeFilds.Length - 1)
            .ToArray();

        foreach (var i in indexes)
        {
            sizeFilds[i] = 1;
        }

        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("end"))
            {
                break;
            }

            string[] tokens = Regex.Split(command, @"\s+")
                .Select(x => x.Trim())
                .ToArray();

            int ladybugIndex = int.Parse(tokens[0]);
            string direction = tokens[1];
            int flyLength = int.Parse(tokens[2]);

            switch (direction)
            {
                case "right":
                    GetCommandRight(sizeFilds, ladybugIndex, flyLength);
                    break;
                case "left":
                    GetCommandLeft(sizeFilds, ladybugIndex, flyLength);
                    break;
            }
        }

        Console.WriteLine(String.Join(" ", sizeFilds));
    }

    static void GetCommandLeft(int[] sizeFilds, int ladybugIndex, int flyLength)
    {
        int flyCount = flyLength;
        int i = sizeFilds.Length - 1;
        while (i >= 0)
        {
            if (i == ladybugIndex)
            {
                sizeFilds[i] = 0;
                break;
            }

            if (i == Math.Abs(ladybugIndex - flyCount) && sizeFilds[i] != 1)
            {
                sizeFilds[i] = 1;
            }
            else if (i == Math.Abs(ladybugIndex - flyCount))
            {
                flyCount = Math.Abs(i - flyLength);
            }

            i--;
        }
    }

    static void GetCommandRight(int[] sizeFilds, int ladybugIndex, int flyLength)
    {
        int flyCount = flyLength;
        int i = 0;
        while (i <= sizeFilds.Length - 1)
        {
            if (i == ladybugIndex)
            {
                sizeFilds[i] = 0;                
            }

            if (i == ladybugIndex + flyCount && sizeFilds[i] != 1)
            {
                sizeFilds[i] = 1;
                break;
            }
            else if (i == ladybugIndex + flyCount)
            {
                flyCount = i + flyLength;
            }

            i++;
        }    
    }
}