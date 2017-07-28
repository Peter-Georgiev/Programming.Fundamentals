using System;
using System.Linq;

class Ladybugs
{
    static void Main()
    {
        int[] sizeFilds = new int[int.Parse(Console.ReadLine())];
        int[] indexes = Console.ReadLine()
            .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
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

            string[] tokens = command
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            int ladybugIndex = int.Parse(tokens[0]);
            string direction = tokens[1];
            int flyLength = int.Parse(tokens[2]);

            if (ladybugIndex < 0 || ladybugIndex >= sizeFilds.Length)
            {
                continue;
            }

            if (sizeFilds[ladybugIndex] == 0)
            {
                continue;
            }

            sizeFilds[ladybugIndex] = 0;

            var position = ladybugIndex;

            while (true)
            {
                if (direction == "right")
                {
                    position += flyLength;
                }
                else
                {
                    position -= flyLength;
                }

                if (position < 0 || position >= sizeFilds.Length)
                {
                    break;
                }

                if (sizeFilds[position] == 1)
                {
                    continue;
                }
                else
                {
                    sizeFilds[position] = 1;
                    break;
                }
            }
        }

        Console.WriteLine(String.Join(" ", sizeFilds));
    }
}