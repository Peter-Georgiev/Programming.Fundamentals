using System;
using System.Linq;

class ArrayContainsElement
{
    static void Main()
    {
        int[] readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int n = int.Parse(Console.ReadLine());

        bool isFound = false;

        foreach (var find in readLine)
        {
            if (find == n)
            {
                isFound = true;
                break;
            }
        }

        if (isFound)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}