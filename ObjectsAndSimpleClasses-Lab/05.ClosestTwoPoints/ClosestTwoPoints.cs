using System;
using System.Collections.Generic;
using System.Linq;

class ClosestTwoPoints
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var points = new List<Point>();

        for (int i = 0; i < n; i++)
        {
            var currentPoint = ReadPoint();
            points.Add(currentPoint);
        }

        var minimumDistance = double.MaxValue;
        Point firstPointResult = null;
        Point secondPointResult = null;

        for (int first = 0; first < points.Count; first++)
        {
            for (int second = first + 1; second < points.Count; second++)
            {
                var firstPont = points[first];
                var secondPoint = points[second];

                var distance = Distance(firstPont, secondPoint);

                if (distance < minimumDistance)
                {
                    minimumDistance = distance;

                    firstPointResult = firstPont;
                    secondPointResult = secondPoint;
                }
            }
        }

        Console.WriteLine("{0:F3}", minimumDistance);
        Console.WriteLine(firstPointResult.Print());
        Console.WriteLine(secondPointResult.Print());
    }

    public static double Distance(Point first, Point second)
    {
        var squareX = Math.Pow(first.X - second.X, 2);
        var squareY = Math.Pow(first.Y - second.Y, 2);

        var result = Math.Sqrt(squareX + squareY);

        return result;
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
}

internal class Point
{
    public int X { get; set; }

    public int Y { get; set; }

    public string Print()
    {
        return $"({X}, {Y})";
    }
}