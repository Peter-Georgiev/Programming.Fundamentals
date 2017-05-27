using System;
using System.Collections.Generic;

class SMStyping
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string message = "";
        while (n > 0)
        {
            string digits = Console.ReadLine();
            int mainDigit = int.Parse(digits[0].ToString());
            int offset = (mainDigit - 2) * 3;

            if (mainDigit == 8 || mainDigit == 9)
            {
                offset++;
            }

            int letterIndex = offset + digits.Length - 1;

            if (mainDigit == 0)
            {
                message += " ";
            }
            else
            {
                message += (char)(97 + letterIndex);
            }

            n--;
        }

        Console.WriteLine(message);





        // Option two.
        //char[] set2 = new char[] { 'a', 'b', 'c' };
        //char[] set3 = new char[] { 'd', 'e', 'f' };
        //char[] set4 = new char[] { 'g', 'h', 'i' };
        //char[] set5 = new char[] { 'j', 'k', 'l' };
        //char[] set6 = new char[] { 'm', 'n', 'o' };
        //char[] set7 = new char[] { 'p', 'q', 'r', 's' };
        //char[] set8 = new char[] { 't', 'u', 'v' };
        //char[] set9 = new char[] { 'w', 'x', 'y', 'z' };
        //char[] space = new char[] { ' ' };
        //List<char> text = new List<char>();

        //int n = int.Parse(Console.ReadLine());

        //while (n > 0)
        //{
        //    string number = Console.ReadLine();

        //    char[] set;
        //    switch (number[0])
        //    {
        //        case '2':
        //            set = (char[])set2.Clone();
        //            break;
        //        case '3':
        //            set = (char[])set3.Clone();
        //            break;
        //        case '4':
        //            set = (char[])set4.Clone();
        //            break;
        //        case '5':
        //            set = (char[])set5.Clone();
        //            break;
        //        case '6':
        //            set = (char[])set6.Clone();
        //            break;
        //        case '7':
        //            set = (char[])set7.Clone();
        //            break;
        //        case '8':
        //            set = (char[])set8.Clone();
        //            break;
        //        case '9':
        //            set = (char[])set9.Clone();
        //            break;
        //        default:
        //            set = (char[])space.Clone();
        //            break;
        //    }

        //    for (int i = 0; i < set.Length; i++)
        //    {
        //        if (i == number.Length - 1)
        //        {
        //            text.Add(set[i]);
        //        }
        //    }

        //    n--;
        //}

        //foreach (var print in text)
        //{
        //    Console.Write(print);
        //}

        //Console.WriteLine();
    }
}