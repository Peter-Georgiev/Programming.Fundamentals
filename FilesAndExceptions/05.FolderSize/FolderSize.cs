using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class FolderSize
{
    static void Main()
    {
        string[] filesDirectory = Directory.GetFiles(@"D:\temp");

        var filesLenght = new Dictionary<string, double>();

        for (int i = 0; i < filesDirectory.Length; i++)
        {
            if (!filesLenght.ContainsKey(filesDirectory[i]))
            {
                double fLenghtMB = new FileInfo(filesDirectory[i]).Length / 1024d / 1024d;
                filesLenght.Add(filesDirectory[i], fLenghtMB);
            }
        }

        double output = filesLenght.Select(x => x.Value).ToList().Sum();

        File.WriteAllText("Output.txt", Convert.ToString($"Oll size file:{output:F2} MB"));
    }
}