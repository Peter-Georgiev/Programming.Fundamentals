using System;
using System.Linq;

class TrippleSum
{
    static void Main()
    {
        string lineRead = Console.ReadLine();

        string[] tempIntegersArr = lineRead.Split(' ');
        int[] integersArr = new int[tempIntegersArr.Length];

        for (int i = 0; i < integersArr.Length; i++)
        {
            integersArr[i] = int.Parse(tempIntegersArr[i]);
        }

        bool isNo = true;

        for (int i = 0; i < integersArr.Length; i++)
        {
            for (int i2 = i + 1; i2 < integersArr.Length; i2++)
            {
                bool isDifference = i < i2;
                int sum = integersArr[i] + integersArr[i2];
                bool isSum = integersArr.Contains(sum);

                if (isSum && isDifference)
                {
                    Console.WriteLine($"{integersArr[i]} + {integersArr[i2]} == {sum}");
                    isNo = false;
                }
            }
        }

        if (isNo)
        {
            Console.WriteLine("No");
        }
    }
}