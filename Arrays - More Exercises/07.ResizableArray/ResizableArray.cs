using System;
using System.Linq;

class ResizableArray
{
    static void Main()
    {
        int?[] array = new int?[4];
        string[] command = Console.ReadLine().Split(' ').ToArray();
        
        while (!command[0].Equals("end"))
        {
            if (command[0].Equals("push"))
            {
                array = PushArray(command, array);
            }
            else if (command[0].Equals("pop"))
            {
                array = PopArray(command, array);
            }
            else if (command[0].Equals("removeAt"))
            {
                array = RemoveAtArray(command, array);
            }
            else if (command[0].Equals("clear"))
            {
                array = ClearArray(command, array);
            }

            command = Console.ReadLine().Split(' ').ToArray();
        }

        byte empty = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Equals(null))
            {
                empty++;
            }
        }

        if (empty == array.Length)
        {
            Console.WriteLine("empty array");
        }
        else
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (!array[i].Equals(null))
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }       
    }

    private static int?[] PushArray(string[] command, int?[] array)
    {        
        bool isSmallArray = false;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Equals(null))
            {
                array[i] = int.Parse(command[1]);
                isSmallArray = false;
                break;
            }
            else
            {
                isSmallArray = true;
            }
        }

        int?[] newArray = new int?[array.Length * 2];
        if (isSmallArray)
        {
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i].Equals(null))
                {
                    newArray[i] = int.Parse(command[1]);
                    break;
                }
            }

            return newArray;
        }
        else
        {
            return array;
        }       
    }

    private static int?[] PopArray(string[] command, int?[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Equals(null))
            {
                array[i - 1] = null;
                break;
            }
        }

        return array;
    }

    private static int?[] RemoveAtArray(string[] command, int?[] array)
    {
        int star = 0;
        for (int i = 0; i < array.Length; i++)
        {            
            if (i.Equals(int.Parse(command[1])))
            {
                array[i] = null;
                star = i;
                break;
            }
        }

        for (int i = star + 1; i < array.Length; i++)
        {
            array[i - 1] = array[i];
        }

        return array;
    }

    private static int?[] ClearArray(string[] command, int?[] array)
    {
        array = new int?[4];
        return array;
    }
}