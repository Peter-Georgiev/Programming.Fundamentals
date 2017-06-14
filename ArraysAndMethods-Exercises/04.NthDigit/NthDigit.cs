using System;

class NthDigit
{
    static void Main()
    {
        int readInteger = int.Parse(Console.ReadLine());
        int index = int.Parse(Console.ReadLine());

        byte result = FindNthDigit(readInteger, index);

        PrintNthDigit(result);        
    }

    static byte FindNthDigit(long readInteger, int index)
    {
        long result = 0;

        while (index > 0)
        {
            result = readInteger % 10;
            readInteger /= 10;
            index--;
        }

        return (byte)result;
    }

    static void PrintNthDigit(byte result )
    {
        Console.WriteLine(result);
    }
}