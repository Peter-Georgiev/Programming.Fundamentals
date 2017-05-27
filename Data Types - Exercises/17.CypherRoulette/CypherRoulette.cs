using System;
using System.Collections.Generic;

class CypherRoulette
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string cypherString = "";
        string prevString = "";
        string currString;
        string concatMode = "NormalMode";

        while (n > 0)
        {
            currString = Console.ReadLine();

            if (prevString == currString)
            {
                cypherString = string.Empty;

                if (prevString != "spin")
                {
                    n--;
                }
                continue;
            }

            if (currString != "spin")
            {
                n--;
            }
            else
            {
                if (concatMode == "SpinMode")
                {
                    concatMode = "NormalMode";
                }
                else
                {
                    concatMode = "SpinMode";
                }

                prevString = currString;
                continue;
            }

            switch (concatMode)
            {
                case ("NormalMode"):
                    cypherString = cypherString + currString;
                    break;

                case ("SpinMode"):
                    cypherString = currString + cypherString;
                    break;
            }

            prevString = currString;
        }

        Console.WriteLine(cypherString);

        ///////////-------------60/100-------------///////////
        //List<string> cypherString = new List<string>();
        //byte countSpin = 0;
        //int count = 0;
        //string tempWord = "";

        //while (n > 0)
        //{
        //    string word = Console.ReadLine();            

        //    if ((countSpin % 2 == 1) && !word.Equals("spin"))
        //    {
        //        cypherString.Insert(count, word);
        //        count++;
        //    }
        //    else if ((countSpin % 2 == 0) && !word.Equals("spin"))
        //    {
        //        cypherString.Add(word);
        //        count = 0;
        //    }
        //    else if (!word.Equals("spin"))
        //    {
        //        cypherString.Add(word);

        //    }            

        //    if (word.Equals("spin"))
        //    {
        //        countSpin++;
        //    }
        //    else
        //    {
        //        n--;
        //    }

        //    if (tempWord == word)
        //    {
        //        cypherString.Clear();
        //        countSpin = 0;
        //        count = 0;
        //    }

        //    tempWord = word;
        //    cypherString.Remove("spin");
        //}

        //foreach (var print in cypherString)
        //{
        //    Console.Write(print);
        //}

        //Console.WriteLine();
    }
}