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
            if (array[i] >= n)
            {
                result = array[i];
                break;
            }
        }

        
        for (int i = 0; i < array.Length; i++)
        {

            if (int.MaxValue <= array[i] && array[i] <= long.MaxValue && message.Equals("long"))
            {
                result = array[i];
                break;
            }
            else if (sbyte.MaxValue <= array[i] && array[i] <= int.MaxValue && message.Equals("int"))
            {
                result = array[i];
                break;
            }
            else if (sbyte.MinValue <= array[i] && array[i] <= sbyte.MaxValue && message.Equals("sbyte"))
            {
                result = array[i];
                break;
            }

        }       

        Console.WriteLine(result);
    }
}