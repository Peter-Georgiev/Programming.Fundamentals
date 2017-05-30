using System;
using System.Linq;


class RoundingNumbers
{
    static void Main()
    {        
        string[] nums = Console.ReadLine().Split(',').ToArray();

        int[] integersArr = new int[nums.Length];

        for (int i = 0; i < integersArr.Length; i++)
        {            
            integersArr[i] = int.Parse(nums[i]);
        }

        for (int i = 0; i < integersArr.Length; i++)
        {
            int num = integersArr[i];
            bool isTrue = Math.Round(num, MidpointRounding.AwayFromZero) != 0;
            if (Math.Round(num, MidpointRounding.AwayFromZero))
            {

            }
        }

        if (var round = (int)Math.Round(nums[i], MidpointRounding.AwayFromZero);)
        {

        }
        
    }
}