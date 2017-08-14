using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TrophonTheGrumpyCat
{
    static void Main()
    {
        int[] arr = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        int entryPoint = int.Parse(Console.ReadLine());
        string typeOfItems = Console.ReadLine();
        string typeOfPriceRating = Console.ReadLine();

        if (typeOfItems.Equals("cheap"))
        {
         
        }
        else if (typeOfItems.Equals("expensive"))
        {

        }

        if (typeOfPriceRating.Equals("positive"))
        {

        }
        else if (typeOfPriceRating.Equals("negative"))
        {

        }
        else if (typeOfPriceRating.Equals("all"))
        {

        }

        string input;
        while ((input = Console.ReadLine()) != "end")
        {




        }


#if DEBUG
        Console.WriteLine(4343);
#endif
    }

    static int Cheap(int e)
    {
        throw new NotImplementedException();
    }
}