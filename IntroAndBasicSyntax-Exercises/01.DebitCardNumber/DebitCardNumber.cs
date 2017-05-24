using System;

class DebitCardNumber
{
    static void Main()
    {
        int[] numCard = new int[4];

        for (int i = 0; i < 4; i++)
        {
            numCard[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < numCard.Length; i++)
        {
            Console.Write($"{numCard[i]:D4} ");
        }
        Console.WriteLine();
    }
}