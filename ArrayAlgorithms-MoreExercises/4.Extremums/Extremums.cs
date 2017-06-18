using System;
using System.Collections.Generic;
using System.Linq;

class Extremums
{
    static void Main()
    {
        int[] readLine = Console.ReadLine()
            .Split(' ').Select(int.Parse).ToArray();
        string commant = Console.ReadLine();

        List<int> output = new List<int>();

        for (int i = 0; i < readLine.Length; i++)
        {            
            List<int> tempNumber = new List<int>();
            int digit = readLine[i];
            string tempStr = string.Empty;

            while (digit > 0)
            {
                tempNumber.Add(digit % 10);
                digit /= 10;
            }
            tempNumber.Reverse();
            tempStr = string.Join(" ", tempNumber);

            int[] leftRotation = tempStr.Split(' ').Select(int.Parse).ToArray();

            for (int left = 0; left < leftRotation.Length - 1; left++)
            {
                var temp = leftRotation[left + 1];
                leftRotation[left + 1] = leftRotation[left];
                leftRotation[left] = temp;
            }

            int[] rightRotation = tempStr.Split(' ').Select(int.Parse).ToArray();

            for (int right = rightRotation.Length - 1; right > 0; right--)
            {
                var temp = rightRotation[right - 1];
                rightRotation[right - 1] = rightRotation[right];
                rightRotation[right] = temp;
            }

            int leftR = Convert.ToInt32(string.Join("", leftRotation));
            int rightR = Convert.ToInt32(string.Join("", rightRotation));
            int input = Convert.ToInt32(string.Join("", readLine[i]));

            tempNumber = new List<int>();

            tempNumber.Add(leftR);
            tempNumber.Add(rightR);
            tempNumber.Add(input);

            if (commant.Equals("Max"))
            {
                output.Add(tempNumber.Max());
            }
            else if (commant.Equals("Min"))
            {
                output.Add(tempNumber.Min());
            }
        }

        Console.WriteLine(string.Join(", ", output));
        Console.WriteLine(output.Sum());
    }
}