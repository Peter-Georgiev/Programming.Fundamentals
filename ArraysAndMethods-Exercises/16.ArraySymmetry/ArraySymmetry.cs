using System;
using System.Linq;

class ArraySymmetry
{
    static void Main()
    {
        string[] arrayOfString = Console.ReadLine().Split(' ').ToArray();

        int last = arrayOfString.Length - 1;
        string message = null;
        for (int i = 0; i < arrayOfString.Length / 2; i++)
        {
            
            if (arrayOfString[i] == arrayOfString[last])
            {
                message = "Yes";
            }
            else
            {
                message = "No";
                break;
            }

            last--;
        }

        Console.WriteLine(message);
    }
}