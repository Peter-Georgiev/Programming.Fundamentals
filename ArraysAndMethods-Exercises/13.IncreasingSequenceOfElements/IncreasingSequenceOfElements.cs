using System;
using System.Linq;

class IncreasingSequenceOfElements
{
    static void Main()
    {
        int[] arrayOfInteger = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        string message = null;

        for (int i = 0; i < arrayOfInteger.Length - 1; i++)
        {
            if (arrayOfInteger[i + 1] > arrayOfInteger[i])
            {
                message = "Yes";
            }
            else
            {
                message = "No";
                break;
            }
        }

        Console.WriteLine(message);
    }
}