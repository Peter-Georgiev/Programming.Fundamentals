using System;

class TestNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int maxSum = int.Parse(Console.ReadLine());

        int sum = 0;
        int count = 0;
        string message = "";

        for (int count1 = n; count1 >= 1; count1--)
        {
            for (int count2 = 1; count2 <= m; count2++)
            {
                count++;
                sum += 3 * (count1 * count2);
                
                if (sum >= maxSum)
                {
                    message = $"Sum: {sum} >= {maxSum}";
                    break;
                }
                else
                {
                    message = $"Sum: {sum}";
                }
            }
            if (sum >= maxSum)
            {
                break;
            }
        }

        Console.WriteLine($"{count} combinations");
        Console.WriteLine($"{message}");
    }
}