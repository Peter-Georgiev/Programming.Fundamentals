using System;
using System.Collections.Generic;
using System.Linq;

class TrackDownloader
{
    static void Main()
    {
        string[] blackList = Console.ReadLine().Split(' ').ToArray();

        List<string> filenames = ReadFilname();

        List<string> printFilename = PrintFilename(blackList, filenames);

        printFilename.ForEach(Console.WriteLine);
    }

    private static List<string> PrintFilename(string[] blackList, List<string> filenames)
    {
        List<string> printFilename = new List<string>(filenames.Count);

        for (int i = 0; i < filenames.Count; i++)
        {
            bool isBlackList = false;

            for (int j = 0; j < blackList.Length; j++)
            {
                isBlackList = filenames[i].Contains(blackList[j]);

                if (filenames[i].Contains(blackList[j]))
                {
                    break;
                }
            }

            if (!isBlackList)
            {
                printFilename.Add(filenames[i]);
            }
            printFilename.Sort();
        }

        return printFilename;
    }

    private static List<string> ReadFilname()
    {
        List<string> filenaames = new List<string>();
        string readFilname = Console.ReadLine();

        while (!readFilname.Equals("end"))
        {
            filenaames.Add(readFilname);
            readFilname = Console.ReadLine();
        }

        return filenaames;
    }
}