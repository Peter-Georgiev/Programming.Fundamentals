using System;
using System.Linq;

class DistanceBetweenPoints
{
    static void Main()
    {
        var firstPoint = ReadPoint();

        var secondPoint = ReadPoint();

        var result = Distance(firstPoint, secondPoint);

        Console.WriteLine("{0:F3}", result);
    }

    private static Point ReadPoint()
    {
        int[] pointsParts = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        return new Point
        {
            X = pointsParts[0],
            Y = pointsParts[1]
        };
    }

    public static double Distance(Point first, Point second)
    {
        var squareX = Math.Pow(first.X - second.X, 2);
        var squareY = Math.Pow(first.Y - second.Y, 2);

        var result = Math.Sqrt(squareX + squareY);

        return result;
    }

}

internal class Point
{
    public double X { get; set; }
    public double Y { get; set; }
}