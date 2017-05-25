using System;

class CountTheIntegers
{
    static void Main()
    {
        int count = 0;
        try
        {
            int countLine = int.Parse(Console.ReadLine());
            
            while (true)
            {
                count++;
                countLine = int.Parse(Console.ReadLine());
            }
        }
        catch (Exception)
        {

            Console.WriteLine(count);
        }
    }
}