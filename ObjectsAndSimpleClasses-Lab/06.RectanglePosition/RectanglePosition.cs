using System;
using System.Linq;
using RectangleClass;

class RectanglePosition
{
    static void Main()
    {
        var firstRect = ReadRectangle();
        var secondRect = ReadRectangle();

        Console.WriteLine(firstRect.IsInside(secondRect) 
            ? "Inside" : "Not inside");
    }

    public static Rectangle ReadRectangle()
    {
        int[] pointsParts = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        return new Rectangle
        {
            Left = pointsParts[0],
            Top = pointsParts[1],
            Width = pointsParts[2],
            Height = pointsParts[3]
        };
    }
}