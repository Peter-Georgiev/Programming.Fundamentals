using System;
using System.Collections.Generic;
using System.Linq;

class Box
{
    public Point UpperLeft { get; set; }

    public Point UpperRight { get; set; }

    public Point BottomLeft { get; set; }

    public Point BottomRight { get; set; }

    public int CalculateArea(int width, int height)
    {
        return (width * height);
    }

    public int CalculatePerimeter(int width, int height)
    {
        return (2 * width + 2 * height);
    }
}

class Point
{
    public int X { get; set; }

    public int Y { get; set; }

    public int CalculateDistance(Point p1, Point p2)
    {
        int deltaX = p2.X - p1.X;
        int deltaY = p2.Y - p1.Y;
        return (int)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}

class Boxes
{
    static void Main()
    {
        List<string> boxes = new List<string>();

        ReadLineAndCalculate(boxes);

        PrintResult(boxes);
    }

    public static void PrintResult(List<string> boxes)
    {
        foreach (var print in boxes)
        {
            Console.WriteLine(print);
        }
    }

    public static void ReadLineAndCalculate(List<string> boxes)
    {
        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("end"))
            {
                break;
            }

            int[] tokens = readLine
                 .Split(new[] { ' ', '|', ':' },
                 StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Box readBoxes = new Box()
            {
                UpperLeft = new Point
                {
                    X = tokens[0],
                    Y = tokens[1]
                },
                UpperRight = new Point
                {
                    X = tokens[2],
                    Y = tokens[3]
                },
                BottomLeft = new Point
                {
                    X = tokens[4],
                    Y = tokens[5]
                },
                BottomRight = new Point
                {
                    X = tokens[6],
                    Y = tokens[7]
                }
            };

            int widthBox =  new Point()
                .CalculateDistance(readBoxes.UpperLeft, readBoxes.UpperRight);
            int heightBox = new Point()
                .CalculateDistance(readBoxes.UpperLeft, readBoxes.BottomLeft);
            int perimeter = new Box().CalculatePerimeter(widthBox, heightBox);
            int area = new Box().CalculateArea(widthBox, heightBox);
            
            boxes.Add($"Box: {widthBox}, {heightBox}");
            boxes.Add($"Perimeter: {perimeter}");
            boxes.Add($"Area: {area}");
        }
    }
}