﻿using System;
class RefactorVolumeOfPyramid
{
    static void Main()
    {
        Console.Write("Length: ");
        double lenght = double.Parse(Console.ReadLine());

        Console.Write("Width: ");
        double width = double.Parse(Console.ReadLine());

        Console.Write("Heigth: ");
        double height = double.Parse(Console.ReadLine());

        double volume = ((lenght * width) * height) / 3;

        Console.WriteLine("Pyramid Volume: {0:F2}", volume);
    }
}