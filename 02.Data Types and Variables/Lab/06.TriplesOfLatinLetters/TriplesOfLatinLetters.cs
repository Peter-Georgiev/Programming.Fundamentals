using System;

class TriplesOfLatinLetters
{
    static void Main()
    {

        int num = int.Parse(Console.ReadLine());

        char letter = (char)('a' + num);

        for (int i1 = 'a'; i1 < letter; i1++)
        {
            for (int i2 = 'a'; i2 < letter; i2++)
            {
                for (int i3 = 'a'; i3 < letter; i3++)
                {
                    Console.WriteLine($"{Convert.ToChar(i1)}{Convert.ToChar(i2)}{Convert.ToChar(i3)}");
                }
            }
        }
    }
}