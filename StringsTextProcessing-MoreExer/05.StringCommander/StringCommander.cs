using System;
using System.Linq;

class StringCommander
{
    static void Main()
    {
        string input = Console.ReadLine();

        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("end"))
            {
                break;
            }

            string[] tokens = command
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            command = tokens[0];

            switch (command)
            {
                case "Left":
                    LeftCountTimes(tokens, ref input);
                    break;
                case "Right":
                    RightCountTimes(tokens, ref input);
                    break;
                case "Insert":
                    InsertStringIndex(tokens, ref input);
                    break;
                case "Delete":
                    DeleteStartEndIndex(tokens, ref input);
                    break;
            }
        }

        Console.WriteLine(input);
    }

    private static void RightCountTimes(string[] tokens, ref string input)
    {
        int count = int.Parse(tokens[1]) % input.Length;
        char[] temp = input.ToCharArray(); ;

        for (int times = 0; times < count; times++)
        {
            char lastElement = temp[temp.Length - 1];

            for (int i = temp.Length - 1; i > 0; i--)
            {
                temp[i] = temp[i - 1];
            }

            temp[0] = lastElement;
        }

        input = string.Join("", temp);
    }

    private static void LeftCountTimes(string[] tokens, ref string input)
    {
        int count = int.Parse(tokens[1]) % input.Length;
        char[] temp = input.ToCharArray();

        for (int times = 0; times < count; times++)
        {
            char firstelement = temp[0];

            for (int i = 0; i < temp.Length - 1; i++)
            {
                temp[i] = temp[i + 1];
            }

            temp[temp.Length - 1] = firstelement;
        }

        input = string.Join("", temp);
    }

    private static void InsertStringIndex(string[] tokens, ref string input)
    {
        int index = int.Parse(tokens[1]);
        string str = tokens[2];

        input = input.Insert(index, str);
    }

    private static void DeleteStartEndIndex(string[] tokens, ref string input)
    {
        int startIndex = int.Parse(tokens[1]);
        int endIndex = int.Parse(tokens[2]);

        input = input.Remove(startIndex, endIndex - startIndex + 1);
    }
}