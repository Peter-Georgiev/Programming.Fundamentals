﻿using System;

class ExchangeVariableValues
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        int temp = a;
        a = b;
        b = temp;

        //After
        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}