using System;
using System.Collections.Generic;
using System.Linq;

class Spyfer
{
    static void Main()
    {
        List<int> arr = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        for (int i = 0; i < arr.Count; i++)
        {
            if ((i > 0 && i < arr.Count - 1) && (arr[i - 1] + arr[i + 1] == arr[i]))
            {
                arr.RemoveAt(i + 1);
                arr.RemoveAt(i - 1);
                i = 0;
            }
            else if ((i > 0 && i < arr.Count) && (arr[i - 1] == arr[i]))
            {
                arr.RemoveAt(i - 1);
                i = 0;
            }
            else if ((i >= 0 && i < arr.Count - 1) && (arr[i + 1] == arr[i]))
            {
                arr.RemoveAt(i + 1);
                i = 0;
            }
        }

        Console.WriteLine(String.Join(" ", arr));
    }
}