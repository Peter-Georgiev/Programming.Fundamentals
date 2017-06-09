using System;
using System.Collections.Generic;
using System.Linq;

class TearListInHalf
{
    static void Main()
    {
        int[] readLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int[] leftHalf = CopyToHalf(readLine, 0);
        int[] rightHalf = CopyToHalf(readLine, readLine.Length / 2);

        int[] divisorRightHalf = DivisorRightHalf(rightHalf);

        PrintResult(leftHalf, divisorRightHalf);
    }

    private static int[] CopyToHalf(int[] readLine, int n)
    {
        int[] half = new int[readLine.Length / 2];
        for (int i = 0; i < half.Length; i++, n++)
        {
            half[i] = readLine[n];
        }

        return half;
    }

    private static int[] DivisorRightHalf(int[] rightHalf)
    {
        int[] divisorRightHalf = new int[rightHalf.Length * 2];
        for (int i = 0, d = 0; i < rightHalf.Length; i++, d += 2)
        {
            var x = rightHalf[i] % 10;
            var y = rightHalf[i] / 10;
            divisorRightHalf[d] = y;
            divisorRightHalf[d + 1] = x;
        }

        return divisorRightHalf;
    }

    private static void PrintResult(int[] leftHalf, int[] divisorRightHalf)
    {
        List<int> printResult = new List<int>();
        byte countLefthalf = 0;
        byte countDivisor = 0;
        byte countExit = 1; 

        for (int i = 1; i <= 4; i++)
        {
            if (i == 4)
            {
                i = 1;
            }

            if (i % 2 == 0)
            {
                printResult.Add(leftHalf[countLefthalf]);
                countLefthalf++;
            }
            else
            {
                printResult.Add(divisorRightHalf[countDivisor]);
                countDivisor++;
            }            

            if (countExit == divisorRightHalf.Length + leftHalf.Length)
            {
                break;
            }

            countExit++;
        }

        Console.WriteLine(string.Join(" ", printResult));
    }
}