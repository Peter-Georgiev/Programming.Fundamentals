using System;
using System.IO;
using System.Linq;

class FilterExtensions
{
    static void Main()
    {
        string inputFolder = @"..\..\..\Exercises-Resource\01. Filter-Extensions\input";

        string[] allFilesDir = Directory.GetFiles(inputFolder);

        string readLine = Console.ReadLine().ToLower();

        for (int i = 0; i < allFilesDir.Length; i++)
        {
            var fileName = new FileInfo(allFilesDir[i]).Name;
            string[] extensionFile = fileName.Split('.').ToArray();

            if (readLine == extensionFile[extensionFile.Length - 1])
            {
                Console.WriteLine(fileName);
            }
        }
    }
}