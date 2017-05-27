using System;

class VariableInHexadecimalFormat
{
    static void Main()
    {
        string convert = Console.ReadLine();
        
        Console.WriteLine(Convert.ToInt32(convert, 16));
    }
}