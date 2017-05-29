using System;

class GreaterOfTwoValues
{
    static void Main()
    {
        string name = Console.ReadLine();


        if (name.ToLower().Equals("int"))
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int max = GetMaxInteger(first, second);
            Console.WriteLine(max);
        }
        else if (name.ToLower().Equals("char"))
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char max = GetMaxChar(first, second);
            Console.WriteLine(max);
        }
        else if (name.ToLower().Equals("string"))
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            string max = GetMaxString(first, second);
            Console.WriteLine(max);
        }
    }

    public static int GetMaxInteger(int first, int second)
    {
        if (first >= second)
        {
            return first;
        }
        else
        {
            return second;
        }
    }

    public static char GetMaxChar(char first, char second)
    {
        if (first >= second)
        {
            return first;
        }
        else
        {
            return second;
        }
    }

    public static string GetMaxString(string first, string second)
    {
        if (first.CompareTo(second) >= 0)
        {
            return first;
        }
        else
        {
            return second;
        }
    }
}