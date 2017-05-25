using System;

class n5DifferentNumbers
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        if (b - a < 5)
        {
            Console.WriteLine("No");
        }
        else
        {
            for (int n1 = a; n1 <= b; n1++)
            {
                for (int n2 = a; n2 <= b; n2++)
                {
                    for (int n3 = a; n3 <= b; n3++)
                    {
                        for (int n4 = a; n4 <= b; n4++)
                        {
                            for (int n5 = a; n5 <= b; n5++)
                            {
                                if (n1 < n2 && n2 < n3 && n3 < n4 && n4 < n5)
                                {
                                    Console.WriteLine($"{n1} {n2} {n3} {n4} {n5}");
                                }                                
                            }
                        }
                    }
                }
            }
        }
    }
}