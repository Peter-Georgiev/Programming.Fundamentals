using System;
using System.Collections.Generic;
using System.Linq;

class AppendLists
{
    static void Main()
    {
        string input = Console.ReadLine();
                
        List<int> printInput = new List<int>();
        string temp = string.Empty;
        int count = 0;

        while (count < input.Length)
        {
            for (int i = count; i < input.Length; i++, count++)
            {
                if ((char)input[i] != '|')
                {
                    temp += Char.ToString(input[i]);
                }
                else
                {
                    break;
                }
            }

            count++;
            int[] tempArr = temp
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)                
                .Select(Int32.Parse)
                .ToArray();
            Array.Reverse(tempArr);
            temp = string.Empty;

            foreach (var item in tempArr)
            {
                printInput.Insert(0, item);
            }
        }        

        Console.WriteLine(string.Join(" ", printInput));
    }
}
