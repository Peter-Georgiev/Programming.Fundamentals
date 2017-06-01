using System;
using System.Linq;

class RotateAndSum
{
    static void Main()
    {
        string[] line = Console.ReadLine().Split(' ').ToArray();        
        int k = int.Parse(Console.ReadLine());

        int[] n = new int[line.Length];
        for (int i = 0; i < line.Length; i++)
        {
            n[i] = int.Parse(line[i]);
        }

        int[] tempArr = null;
        while (k > 0)
        {
            int rotationsCount = 1;
            for (int i = 0; i < rotationsCount; i++)
            {
                int temp = n[n.Length - 1];
                for (int r = n.Length - 1; r >= 1; r--)
                {
                    n[r] = n[r - 1];
                }

                n[i] = temp;
            }

            rotationsCount++;
            if (tempArr.Length != 0)
            {
                for (int i = 0; i < n.Length; i++)
                {
                    n[i] = tempArr[i] + n[i];
                }
            }

            tempArr = n;
            k--;
        }

        foreach (var print in n)
        {
            Console.Write($"{print} ");
        }
        

        
    }
}