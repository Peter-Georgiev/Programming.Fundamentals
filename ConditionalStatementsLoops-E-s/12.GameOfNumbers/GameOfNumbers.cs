using System;

class GameOfNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int magical = int.Parse(Console.ReadLine());

        int sumMagical = 0;
        int count = 0;
        string message = "";

        for (int count1 = n; count1 <= m; count1++)
        {
            for (int count2 = n; count2 <= m; count2++)
            {
                count++;
                sumMagical = count2 + count1;

                if (sumMagical == magical)
                {
                    message = $"Number found! {count2} + {count1} = {sumMagical}";
                    break;
                }                
            }
            if (sumMagical == magical)
            {
                break;
            }
            else
            {
                message = $"{count} combinations - neither equals {magical}";
            }
        }
        
        Console.WriteLine($"{message}");
    }
}