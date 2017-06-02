using System;
using System.Linq;

class FoldAndSum
{
    static void Main()
    {
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int[] leftTemp = new int[array.Length / 4];
        int[] rightTemp = new int[array.Length / 4];

        for (int i = 0; i < array.Length; i++)
        {
            if (i + 1 <= array.Length / 4)
            {
                leftTemp[i] = array[i];
            }
            else if (i - 1 >= (array.Length - (array.Length / 4)) - 1)
            {
                rightTemp[i - (array.Length - (array.Length / 4))] = array[i];
            }            
        }

        Array.Reverse(leftTemp);
        Array.Reverse(rightTemp);

        int[] firstRow = new int[array.Length / 2];
        for (int i = 0; i < firstRow.Length; i++)
        {
            if (i <= leftTemp.Length - 1)
            {
                firstRow[i] = leftTemp[i];
            }
            else
            {
                firstRow[i] = rightTemp[i - rightTemp.Length];
            }            
        }

        int[] secondRow = new int[array.Length / 2];
        for (int i = 0; i < array.Length; i++)
        {
            if (i >= array.Length / 4 && (array.Length - (array.Length / 4) > i))
            {
                secondRow[i - array.Length / 4] = array[i];
            }
        }

        for (int i = 0; i < array.Length / 2; i++)
        {

            Console.Write($"{firstRow[i] + secondRow[i]} ");
        }

        Console.WriteLine();
    }
}