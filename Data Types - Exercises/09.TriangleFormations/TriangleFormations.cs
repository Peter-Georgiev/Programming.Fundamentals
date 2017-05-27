using System;

class TriangleFormations
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        string validOrInvalid = "Invalid Triangle.";
        bool isValid = false;

        if (a + b > c)
        {
            if (a + c > b)
            {
                if (b + c > a)
                {
                    validOrInvalid = "Triangle is valid.";
                    isValid = true;
                }
            }
        }

        Console.WriteLine($"{validOrInvalid}");

        if (a * a + b * b == c * c && isValid)
        {
            Console.WriteLine($"Triangle has a right angle between sides a and b");  
        }
        else if (a * a + c * c == b * b && isValid)
        {
            Console.WriteLine($"Triangle has a right angle between sides a and c");
        }
        else if (b * b + c * c == a * a && isValid)
        {
            Console.WriteLine($"Triangle has a right angle between sides b and c");
        }
        else if (isValid)
        {
            Console.WriteLine($"Triangle has no right angles");
        }
    }
}