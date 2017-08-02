using System;
using System.Linq;

class ValueOfString
{
    static void Main()
    {
        string readLine = Console.ReadLine();
        string command = Console.ReadLine();
        int sum = 0;

        if (command.Equals("UPPERCASE"))
        {
            sum = readLine
                .ToCharArray()
                .Where(x => x >= 'A' && x <= 'Z')
                .ToArray()
                .Sum(x => x);
        }
        else if (command.Equals("LOWERCASE"))
        {
            sum = readLine
                .ToCharArray()
                .Where(x => x >= 'a' && x <= 'z')
                .ToArray()
                .Sum(x => x);
        }

        Console.WriteLine("The total sum is: {0}", sum);
    }
}