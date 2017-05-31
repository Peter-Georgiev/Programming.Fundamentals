using System;
using System.Linq;


class RoundingNumbers
{
    static void Main()
    {        
        string[] nums = Console.ReadLine().Split(' ').ToArray();

        double[] integersArr = new double[nums.Length];

        for (int i = 0; i < integersArr.Length; i++)
        {            
            integersArr[i] = double.Parse(nums[i]);
        }

        for (int i = 0; i < integersArr.Length; i++)
        {
            int numRound = (int)Math.Round(integersArr[i], MidpointRounding.AwayFromZero);
            Console.WriteLine($"{integersArr[i]} => {numRound}");
        }
    }
}