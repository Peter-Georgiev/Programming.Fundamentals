using System;
using System.Linq;

class CompareCharArrays
{
    static void Main()
    {
        char[] arr1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
        char[] arr2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

        int minArr = Math.Min(arr1.Length, arr2.Length);
        int countArr1 = 0;
        int countArr2 = 0;

        for (int i = 0; i < minArr; i++)
        {
            if (arr1[i] <= arr2[i])
            {
                countArr1++;
            }

            if (arr1[i] >= arr2[i])
            {
                countArr2++;
            }
        }

        if (countArr1 == countArr2)
        {
            CheckArrayLenght(arr1, arr2, countArr1, countArr2);
        }
        else
        {
            CheckArrayLenght(arr1, arr2, countArr1, countArr2);
        }
    }

    private static void CheckArrayLenght(char[] arr1, char[] arr2, int countArr1, int countArr2)
    {
        if (countArr1 > countArr2)
        {
            Console.WriteLine(string.Join("", arr1));
            Console.WriteLine(string.Join("", arr2));
        }
        else if (countArr1 < countArr2)
        {
            Console.WriteLine(string.Join("", arr2));
            Console.WriteLine(string.Join("", arr1));
        }
        else if (arr1.Length < arr2.Length)
        {
            Console.WriteLine(string.Join("", arr1));
            Console.WriteLine(string.Join("", arr2));
        }
        else if (arr1.Length >= arr2.Length)
        {
            Console.WriteLine(string.Join("", arr2));
            Console.WriteLine(string.Join("", arr1));
        }
    }
}