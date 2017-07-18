using System;

class PokeMon
{
    static void Main()
    {
        int inputN = int.Parse(Console.ReadLine());
        int inputM = int.Parse(Console.ReadLine());
        byte inputY = byte.Parse(Console.ReadLine());

        int tempN = inputN;
        int count = 0;
        while (true)
        {
            double exactlyN = Math.Round((((double)tempN / inputN) * 100), 1);

            if (tempN.Equals(exactlyN))
            {
                if (tempN > inputY && tempN > 0)
                {
                    tempN = tempN / inputY;
                }

            }
            else if (inputN > inputM)
            {
                tempN = tempN - inputM;
                count++;
            }



        }

    }
}