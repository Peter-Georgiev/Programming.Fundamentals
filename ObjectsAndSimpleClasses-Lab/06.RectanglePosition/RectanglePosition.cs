using System;
//using RectanglePositionClass;
using System.Linq;

class RectanglePosition
{
    static void Main()
    {
        var firstRect = ReadRectangle();
        var secondRec = ReadRectangle();

        Console.WriteLine(firstRect.IsInside(secondRec) ? "Inside" : "Not inside");
    }

    public static Rectangle ReadRectangle()
    {
        int[] pointsParts = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        return new Rectangle
        {
            Top = pointsParts[0],
            Left = pointsParts[1],
            Width = pointsParts[2],
            Height = pointsParts[3]
        };
    }
}

internal class Rectangle
{
    public int Top { get; set; }

    public int Left { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Bottom
    {
        get
        {
            return Top + Height;
        }
    }

    public int Right
    {
        get
        {
            return Left + Width;
        }
    }

    public bool IsInside(Rectangle r)
    {
        return (r.Left <= Left) && (r.Right >= Right)
            && (r.Top <= Top) && (r.Bottom >= Bottom);
    }
}