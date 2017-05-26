using System;

class RefactorVolumeOfPyramid
{
    static void Main()
    {
        double lenght, width, heigth, result = 0;

        Console.Write("Length: ");
        lenght = double.Parse(Console.ReadLine());

        Console.Write("Width: ");
        width = double.Parse(Console.ReadLine());

        Console.Write("Height: ");
        heigth = double.Parse(Console.ReadLine());

        result = ((lenght * width) * heigth) / 3;

        Console.WriteLine("Pyramid Volume: {0:F2}", result);
    }
}