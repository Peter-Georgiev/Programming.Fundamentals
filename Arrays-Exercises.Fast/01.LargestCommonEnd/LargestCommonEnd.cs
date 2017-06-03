using System;
using System.Linq;

class LargestCommonEnd
{
    static void Main()
    {
        string[] inputFirst = Console.ReadLine().Split(' ').ToArray();
        string[] inputSecond = Console.ReadLine().Split(' ').ToArray();
        
        int count = EqualsArray(inputFirst, inputSecond);

        Console.WriteLine(count);
    }

    private static int EqualsArray(string[] inputFirst, string[] inputSecond)
    {
        int countLeft = 0;
        int minArr = Math.Min(inputFirst.Length, inputSecond.Length);
        for (int i = 0; i <= minArr; i++)
        {
            bool isEquals = (inputFirst[i] == inputSecond[i]);
            if (isEquals)
            {
                countLeft++;
            }
            if (i == minArr - 1)
            {
                break;
            }
        }

        Array.Reverse(inputFirst);
        Array.Reverse(inputSecond);

        int countRight = 0;
        for (int i = 0; i <= minArr; i++)
        {
            bool isEquals = (inputFirst[i] == inputSecond[i]);
            if (isEquals)
            {
                countRight++;
            }
            if (i == minArr - 1)
            {
                break;
            }
        }

        if (countLeft > countRight)
        {
            return countLeft;
        }
        else
        {
            return countRight;
        }
    }
}