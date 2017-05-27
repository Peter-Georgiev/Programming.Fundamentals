using System;

class DigitsWithWords
{
    static void Main()
    {
        string word = Console.ReadLine().ToLower();

        byte printNumber;
        switch (word)
        {
            case "one":
                printNumber = 1;
                break;
            case "two":
                printNumber = 2;
                break;
            case "three":
                printNumber = 3;
                break;
            case "four":
                printNumber = 4;
                break;
            case "five":
                printNumber = 5;
                break;
            case "six":
                printNumber = 6;
                break;
            case "seven":
                printNumber = 7;
                break;
            case "eight":
                printNumber = 8;
                break;
            case "nine":
                printNumber = 9;
                break;
            default:
                printNumber = 0;
                break;
        }

        Console.WriteLine(printNumber);
    }
}