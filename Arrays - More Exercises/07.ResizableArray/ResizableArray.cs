using System;
using System.Linq;

class ResizableArray
{
    static void Main()
    {
        //int?[] array = new int?[4];
        string arrayStr = string.Empty;
        string[] command = Console.ReadLine().Split(' ').ToArray();

        while (!command[0].Equals("end"))
        {
            if (command[0].Equals("push"))
            {
                arrayStr = PushArray(command[1], arrayStr);
            }
            else if (command[0].Equals("pop"))
            {
                arrayStr = PopArray(arrayStr);
            }
            else if (command[0].Equals("removeAt"))
            {
                arrayStr = RemoveAtArray(command[1], arrayStr);
            }
            else if (command[0].Equals("clear"))
            {
                arrayStr = ClearArray(arrayStr);
            }

            command = Console.ReadLine().Split(' ').ToArray();
        }

        PrintArray(arrayStr);
    }

    static string PushArray(string command, string arrayStr)
    {
        if (arrayStr != string.Empty)
        {
            arrayStr += ".";
        }
        arrayStr += command;        
        return arrayStr;
    }

    static string PopArray(string arrayStr)
    {
        string newArrayStr = string.Empty;
        int[] tmpNewArrayStr = arrayStr.Split('.').Select(int.Parse).ToArray();

        for (int i = 0; i < tmpNewArrayStr.Length; i++)
        {
            if (!tmpNewArrayStr.Length.Equals(i + 1))
            {
                if (newArrayStr != string.Empty)
                {
                    newArrayStr += ".";
                }
                newArrayStr += tmpNewArrayStr[i];
            }
        }
        return newArrayStr;
    }

    static string RemoveAtArray(string command, string arrayStr)
    {
        string newArrayStr = string.Empty;
        int[] tmpNewArrayStr = arrayStr.Split('.').Select(int.Parse).ToArray();
        
        for (int i = 0; i < tmpNewArrayStr.Length; i++)
        {
            if (!int.Parse(command).Equals(i))
            {
                if (newArrayStr != string.Empty)
                {
                    newArrayStr += ".";
                }
                newArrayStr += tmpNewArrayStr[i];
            }
        }
        return newArrayStr;
    }

    static string ClearArray(string arrayStr)
    {
        arrayStr = string.Empty;
        return arrayStr;
    }

    static void PrintArray(string arrayStr)
    {
        if (arrayStr.Equals(string.Empty))
        {
            Console.WriteLine("empty array");
        }
        else
        {
            int[] arrayPrint = arrayStr.Split('.').Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(" ", arrayPrint));
        }
    }

    //private static int?[] PushArray(string command, int?[] array) //Option two not working 80/100
    //{        
    //    bool isSmallArray = false;
    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        if (array[i].Equals(null))
    //        {
    //            array[i] = int.Parse(command);
    //            isSmallArray = false;
    //            break;
    //        }
    //        else
    //        {
    //            isSmallArray = true;
    //        }
    //    }

    //    int?[] newArray = new int?[array.Length * 2];
    //    if (isSmallArray)
    //    {
    //        for (int i = 0; i < array.Length; i++)
    //        {
    //            newArray[i] = array[i];
    //        }

    //        for (int i = 0; i < newArray.Length; i++)
    //        {
    //            if (newArray[i].Equals(null))
    //            {
    //                newArray[i] = int.Parse(command);
    //                break;
    //            }
    //        }

    //        return newArray;
    //    }
    //    else
    //    {
    //        return array;
    //    }       
    //}

    //private static int?[] PopArray(int?[] array)
    //{
    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        if (array[i].Equals(null) && !array.Max().Equals(null))
    //        {
    //            array[i - 1] = null;
    //            break;
    //        }
    //    }

    //    return array;
    //}

    //private static int?[] RemoveAtArray(string command, int?[] array)
    //{
    //    int star = 0;
    //    for (int i = 0; i < array.Length; i++)
    //    {            
    //        if (i.Equals(int.Parse(command)))
    //        {
    //            array[i] = null;
    //            star = i;
    //            break;
    //        }
    //    }

    //    for (int i = star + 1; i < array.Length; i++)
    //    {
    //        array[i - 1] = array[i];
    //    }

    //    return array;
    //}

    //private static int?[] ClearArray(int?[] array)
    //{
    //    array = new int?[4];
    //    return array;
    //}

    //private static void PrintArray(int?[] array)
    //{
    //    if (array.Max() == null)
    //    {
    //        Console.WriteLine("empty array");
    //    }
    //    else
    //    {
    //        for (int i = 0; i < array.Length; i++)
    //        {
    //            if (!i.Equals(0))
    //            {
    //                Console.Write($" ");
    //            }

    //            if (!array[i].Equals(null))
    //            {
    //                Console.Write($"{array[i]}");
    //            }
    //        }
    //        Console.WriteLine();
    //    }
    //}
}