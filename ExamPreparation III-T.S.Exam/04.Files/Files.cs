using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class PathFile
{
    public string FileName { get; set; }
    public string Extension { get; set; }
    public long SizeFile { get; set; }

    public PathFile(string filename, string extension, long sizeFile)
    {
        this.FileName = filename;
        this.Extension = extension;
        this.SizeFile = sizeFile;
    }
}

class Files
{
    static void Main()
    {
        var path = new Dictionary<string, List<PathFile>>();

        int n = int.Parse(Console.ReadLine());
        ReadLinePathAndFile(path, n);

        string readLine = Console.ReadLine();

        PrintResult(path, readLine);
    }

    static void PrintResult(Dictionary<string, List<PathFile>> path, string readLine)
    {
        string[] tokens = readLine
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToArray();
        string fileExtension = tokens[0];
        string root = tokens[2];

        var result = path
            .Where(x => x.Key.Equals(root))
            .ToDictionary(x => x.Key, x => x.Value);

        if (result.Count.Equals(0))
        {
            Console.WriteLine("No");
            return;
        }

        foreach (var p in result)
        {
            List<PathFile> pathFile = p.Value
                .Where(e => e.Extension.Equals(fileExtension))
                .OrderByDescending(x => x.SizeFile)
                .ThenBy(x => x.FileName)
                .ToList();

            if (pathFile.Count.Equals(0))
            {
                Console.WriteLine("No");
                return;
            }

            foreach (var print in pathFile)
            {
                Console.WriteLine($"{print.FileName} - {print.SizeFile} KB");
            }
        }
    }

    static void ReadLinePathAndFile(Dictionary<string, List<PathFile>> path, int n)
    {
        while (n > 0)
        {
            string[] pathFileSize = Console.ReadLine()
                .Split(new[] { '\\', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            string rootPath = pathFileSize[0];
            string filename = pathFileSize[pathFileSize.Length - 2];
            string[] extensionSplit = Regex.Split(filename, @".*[.](.+)")
                .Where(x => x.Length > 0)
                .Select(x => x.Trim())
                .ToArray();
            string extension = extensionSplit[0];
            long fileSize = long.Parse(pathFileSize[pathFileSize.Length - 1]);

            PathFile newRootFile = new PathFile(filename, extension, fileSize);

            if (!path.ContainsKey(rootPath))
            {
                path.Add(rootPath, new List<PathFile>());
            }

            bool hasNewFileSize = true;
            foreach (var p in path)
            {
                if (p.Key == rootPath)
                {
                    foreach (var f in p.Value)
                    {
                        if (f.FileName == filename)
                        {
                            f.SizeFile = fileSize;
                            hasNewFileSize = false;
                        }
                    }
                }
            }

            if (hasNewFileSize)
            {
                path[rootPath].Add(newRootFile);
            }

            n--;
        }
    }
}