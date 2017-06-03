using System;
using System.Linq;

class CondenseArrayToNumber
{
    static void Main()
    {
        int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] condensed = new int[nums.Length - 1];

        string message = $"{nums[0]} is already condensed to number";

        if (nums.Length > 1)
        {
            while (nums.Length > 1)
            {
                condensed = new int[nums.Length - 1];

                for (int i = 0; i < condensed.Length; i++)
                {
                    condensed[i] = nums[i] + nums[i + 1];
                }

                nums = condensed;
                message = $"{condensed[0]}";
            }
        }       

        Console.WriteLine(message);
    }
}