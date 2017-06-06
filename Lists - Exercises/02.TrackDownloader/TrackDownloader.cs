using System;
using System.Collections.Generic;
using System.Linq;

class TrackDownloader
{
    static void Main()
    {
        string[] blackList = Console.ReadLine().Split(' ').ToArray();
        List<string> fileNames = new List<string>();
        List<string> trackDownload = new List<string>();
        string inputFileName = Console.ReadLine();

        while (!inputFileName.Equals("end"))
        {
            fileNames.Add(inputFileName);

            for (int i = 0; i < fileNames.Count; i++)
            {
                string tempfileName = fileNames[i];
                if (tempfileName.Contains(blackList[0]))
                {
                    trackDownload.Add(fileNames[i]);
                }
            }


            inputFileName = Console.ReadLine();
        }

        foreach (var print in trackDownload)
        {
            Console.WriteLine(print);
        }

        //Console.WriteLine(string.Join(" ", fileNames));

    }
}