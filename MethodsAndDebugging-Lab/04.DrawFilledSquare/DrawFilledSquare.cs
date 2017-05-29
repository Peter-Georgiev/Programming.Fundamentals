using System;

class DrawFilledSquare
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        PrintHeaderRow(number);
        PrintMiddleRow(number);
        PrintHeaderRow(number);
    }

    public static void PrintHeaderRow(int n)
    {
        Console.WriteLine(new string('-', 2 * n));
    }

    public static void PrintMiddleRow(int n)
    {
        for (int col = 0; col < n - 2; col++)
        {
            Console.Write('-');
            for (int row = 1; row < n; row++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine('-');
        }
    }
}