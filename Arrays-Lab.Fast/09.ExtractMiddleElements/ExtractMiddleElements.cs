using System;
using System.Linq;

class ExtractMiddleElements
{
    static void Main()
    {
        MiddleElementOptionsSecond();
        //MiddleElementOptionsFirst();

    }

    private static void MiddleElementOptionsFirst()
    {
        // ----- Options one //Памет: 8.69 MB  //Време: 0.015 s
        int[] middleArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        string message = null;

        if (middleArr.Length > 1)
        {
            for (int i = 0; i < middleArr.Length; i++)
            {
                bool isOddOgEven = middleArr.Length % 2 == 0;

                if (isOddOgEven)
                {
                    message += middleArr[middleArr.Length / 2 - 1] + ", ";
                    message += middleArr[middleArr.Length / 2] + " ";
                    break;
                }
                else
                {
                    message += middleArr[middleArr.Length / 2 - 1] + ", ";
                    message += middleArr[middleArr.Length / 2] + ", ";
                    message += middleArr[middleArr.Length / 2 + 1] + " ";
                    break;
                }
            }
        }
        else
        {
            message = $"{middleArr[0]}";
        }

        Console.WriteLine("{ " + message + " }");
    }

    private static void MiddleElementOptionsSecond()
    {
        int[] middleArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // ----- Options two //Памет: 8.96 MB //Време: 0.015 s
        int[] message = new int[1];

        if (middleArr.Length > 1)
        {
            for (int i = 0; i < middleArr.Length; i++)
            {
                bool isOddOgEven = middleArr.Length % 2 == 0;

                if (isOddOgEven)
                {
                    message = new int[2];
                    message[0] = middleArr[middleArr.Length / 2 - 1];
                    message[1] = middleArr[middleArr.Length / 2];
                    break;
                }
                else
                {
                    message = new int[3];
                    message[0] = middleArr[middleArr.Length / 2 - 1];
                    message[1] = middleArr[middleArr.Length / 2];
                    message[2] = middleArr[middleArr.Length / 2 + 1];
                    break;
                }
            }
        }
        else
        {
            message[0] = middleArr[0];
        }

        Console.WriteLine("{ " + string.Join(", ", message) + " }");
    }
}