using System;
using System.Linq;

class RotateAndSum
{
    static void Main()
    {
        int[] n = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rotation = int.Parse(Console.ReadLine());

        //n = RotatedArray(n);

        int[] sumRotated = new int[n.Length];

        for (int i = 0; i < rotation; i++)
        {
            RotateArray(n, sumRotated);
        }

        //    for (int i = 1; i < rotation; i++)
        //    {
        //        int[] tempRotated = RotatedArray(n);

        //        for (int j = 0; j < n.Length; j++)
        //        {
        //            sumRotated[j] = sumRotated[j] + tempRotated[j];
        //        }

        //        n = tempRotated;
        //    }

            Console.WriteLine(string.Join(" ", sumRotated));
        //}

        //private static int[] RotatedArray(int[] rotated)
        //{
        //    int[] tempRotated = new int[rotated.Length];
        //    tempRotated[0] = rotated[rotated.Length - 1];

        //    for (int r = rotated.Length - 1; r >= 1; r--)
        //    {
        //        tempRotated[r] = rotated[r - 1];
        //    }        

        //    return tempRotated;
        //}
    }

    public static void RotateArray(int[] input, int[] sum)
    {
        var last = input.Length - 1;
        for (var i = 0; i < input.Length - 1; i += 1)
        {
            input[i] ^= input[last];
            input[last] ^= input[i];
            input[i] ^= input[last];
        }
        for (int i = 0; i < input.Length; i++)
        {
            sum[i] += input[i];
        }
    }
}