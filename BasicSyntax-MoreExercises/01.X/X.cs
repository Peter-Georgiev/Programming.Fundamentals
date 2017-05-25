using System;

    class X
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int leftAndRight = 0;
        int center = n;
                
        for (int i = 0; i < n / 2; i++)
        {
            center = n - leftAndRight - 2;
            Console.Write(new string(' ', leftAndRight / 2) + "x");
            Console.Write(new string(' ', center) + "x");
            Console.WriteLine(new string(' ', leftAndRight / 2));
            leftAndRight += 2;
        }

        Console.WriteLine(new string(' ', n / 2) + "x" + new string(' ', n / 2));

        leftAndRight = n - 2;
        center = 1;

        for (int i = 0; i < n / 2; i++)
        {
            
            Console.Write(new string(' ', leftAndRight / 2) + "x");
            Console.WriteLine(new string(' ', center) + "x");
            leftAndRight -= 2;
            center += 2;
        }  
    }
}