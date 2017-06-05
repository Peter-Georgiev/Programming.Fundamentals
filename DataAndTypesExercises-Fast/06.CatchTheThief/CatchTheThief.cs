using System;
using System.Linq;

class CatchTheThief
{
    static void Main()
    {
        string message = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        long[] array = new long[n];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = long.Parse(Console.ReadLine());
        }

        long result = 0;        
        for (int i = 0; i < array.Length; i++)
        {
            bool isLong = int.MaxValue <= array[i] && n <= array[i] &&
                array[i] <= long.MaxValue && message.Equals("long");
            bool isInt = sbyte.MaxValue <= array[i] && n <= array[i] &&
                array[i] <= int.MaxValue && message.Equals("int");
            bool isSbyte = sbyte.MinValue <= array[i] && n <= array[i] &&
                array[i] <= sbyte.MaxValue && message.Equals("sbyte");

            if (isLong)
            {
                result = array[i];
                break;
            }
            else if (isInt)
            {
                result = array[i];
                break;
            }
            else if (isSbyte)
            {
                result = array[i];
                break;
            }
        }       

        Console.WriteLine(result);
    }
}