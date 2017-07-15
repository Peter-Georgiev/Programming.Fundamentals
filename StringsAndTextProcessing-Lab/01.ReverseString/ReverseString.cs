using System;
using System.Linq;

class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        
        string output = new string(input.Reverse().ToArray());

        Console.WriteLine(output);
    }
}