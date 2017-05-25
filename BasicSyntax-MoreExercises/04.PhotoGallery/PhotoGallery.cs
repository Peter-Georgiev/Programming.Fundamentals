using System;

class PhotoGallery
{
    static void Main()
    {
        int photosNumber = int.Parse(Console.ReadLine());
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());
        int hours = int.Parse(Console.ReadLine());
        int minutes = int.Parse(Console.ReadLine());
        double size = double.Parse(Console.ReadLine());
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());

        string orientation = "square";
        if (width > height)
        {
            orientation = "landscape";
        }
        else if (height > width)
        {
            orientation = "portrait";
        }

        string formatSize = "B";
        if (size >= 1000000)
        {
            size /= 1000000d;
            formatSize = "MB";
        }
        else if (size >= 100000)
        {
            size /= 1000;
            formatSize = "KB";
        }

        Console.WriteLine($"Name: DSC_{photosNumber:D4}.jpg");
        Console.WriteLine($"Date Taken: {day:D2}/{month:D2}/{year} {hours:D2}:{minutes:D2}");
        Console.WriteLine($"Size: {size}{formatSize}");
        Console.WriteLine($"Resolution: {width}x{height} ({orientation})");
    }
}