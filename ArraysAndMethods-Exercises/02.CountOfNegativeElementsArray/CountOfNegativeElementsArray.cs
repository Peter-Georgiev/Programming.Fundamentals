using System;

class CountOfNegativeElementsArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] arrayOfNum = new int[n];
        for (int i = 0; i < arrayOfNum.Length; i++)
        {
            arrayOfNum[i] = int.Parse(Console.ReadLine());
        }

        int count = 0;
        for (int i = 0; i < arrayOfNum.Length; i++)
        {
            if (0 > arrayOfNum[i])
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}