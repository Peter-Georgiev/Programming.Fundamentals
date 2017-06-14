using System;
using System.Collections.Generic;

class NumbersToWords
{
    static void Main()
    {
        byte count = byte.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            int number = int.Parse(Console.ReadLine());

            bool isCorrectNumber = -999 <= number && number <= -100 || number >= 100 && number <= 999;

            if (isCorrectNumber)
            {
                List<string> numberToWordConvert = GetNumberToWord(number);

                PrintResult(numberToWordConvert);
            }
            else if (number < -999)
            {
                Console.WriteLine("too small");
            }
            else if (number > 999)
            {
                Console.WriteLine("too large");
            }
        }
    }

    private static List<string> GetNumberToWord(int number)
    {
        List<string> message = new List<string>();

        if (number < 0)
        {
            message.Add("minus ");
            number = Math.Abs(number);
        }

        byte countDigit = 2;
        int[] digitArr = new int[3];
        int count = number;

        while (count > 0)
        {
            digitArr[countDigit] = count % 10;
            countDigit--;
            count /= 10;
        }

        message.Add(GetOneToNine(digitArr[0]));
        message.Add("-");
        message.Add(GetHundredDigit());

        if (number % 100 >= 11 && number % 100 <= 19)
        {
            message.Add(" and ");
            message.Add(GetElevenToNineteen(number % 100));
        }
        else if (number % 100 != 0)
        {
            message.Add(" and ");
            message.Add(GetTwentyToNinety(digitArr[1]));
            message.Add(GetOneToNine(digitArr[2]));
        }

        return message;
    }

    static string GetOneToNine(int digit)
    {
        string digitStr = string.Empty;

        switch (digit)
        {
            case 1:
                digitStr = "one";
                break;
            case 2:
                digitStr = "two";
                break;
            case 3:
                digitStr = "three";
                break;
            case 4:
                digitStr = "four";
                break;
            case 5:
                digitStr = "five";
                break;
            case 6:
                digitStr = "six";
                break;
            case 7:
                digitStr = "seven";
                break;
            case 8:
                digitStr = "eight";
                break;
            case 9:
                digitStr = "nine";
                break;
        }

        return digitStr;
    }

    static string GetTwentyToNinety(int digit)
    {
        string digitStr = string.Empty;

        switch (digit)
        {
            case 2:
                digitStr = "twenty ";
                break;
            case 3:
                digitStr = "thirty ";
                break;
            case 4:
                digitStr = "forty ";
                break;
            case 5:
                digitStr = "fifty ";
                break;
            case 6:
                digitStr = "sixty ";
                break;
            case 7:
                digitStr = "seventy ";
                break;
            case 8:
                digitStr = "eighty ";
                break;
            case 9:
                digitStr = "ninety ";
                break;
        }

        return digitStr;
    }

    static string GetElevenToNineteen(int digit)
    {
        string digitStr = string.Empty;

        switch (digit)
        {
            case 11:
                digitStr = "eleven";
                break;
            case 12:
                digitStr = "twelve";
                break;
            case 13:
                digitStr = "thirteen";
                break;
            case 14:
                digitStr = "fourteen";
                break;
            case 15:
                digitStr = "fifteen";
                break;
            case 16:
                digitStr = "sixteen";
                break;
            case 17:
                digitStr = "seventeen";
                break;
            case 18:
                digitStr = "eighteen";
                break;
            case 19:
                digitStr = "nineteen";
                break;
        }

        return digitStr;
    }

    static string GetHundredDigit()
    {
        string digitStr = "hundred";

        return digitStr;
    }

    static void PrintResult(List<string> message)
    {
        message.ForEach(Console.Write);
        Console.WriteLine();
    }
}