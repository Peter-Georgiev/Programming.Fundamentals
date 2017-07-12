using System.Collections.Generic;
using System.IO;
using System.Linq;

class ReDirectory
{
    static void Main()
    {
        string inputFolder = @"..\..\..\Exercises-Resource\04. Re-Directory\input";
        string outputFolder = @"..\..\..\Exercises-Resource\04. Re-Directory\output";

        var extensionFilesName = new Dictionary<string, List<string>>();

        ReadInputFolder(inputFolder, extensionFilesName);

        WriteOutputFolder(extensionFilesName, inputFolder, outputFolder);
    }

    private static void WriteOutputFolder(Dictionary<string, List<string>> extensionFilesName, string inputFolder, string outputFolder)
    {
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        foreach (var kvp in extensionFilesName)
        {
            if (!Directory.Exists(outputFolder + "\\" + kvp.Key))
            {
                Directory.CreateDirectory(outputFolder + "\\" + kvp.Key);
            }

            foreach (var file in kvp.Value)
            {
                string sourcePath = inputFolder + "\\" + file;
                string destinationPath = outputFolder + "\\" + kvp.Key + "\\" + file;

                File.Copy(sourcePath, destinationPath);
            }
        }
    }

    private static void ReadInputFolder(string inputFolder, Dictionary<string, List<string>> extensionFilesName)
    {
        string[] allFilesDir = Directory.GetFiles(inputFolder);

        for (int i = 0; i < allFilesDir.Length; i++)
        {
            var fileName = new FileInfo(allFilesDir[i]).Name;
            string[] tokensFile = fileName
                .Split('.')
                .ToArray();
            string extensionFile = tokensFile[tokensFile.Length - 1];

            if (!extensionFilesName.ContainsKey(extensionFile))
            {
                extensionFilesName.Add(extensionFile, new List<string>());
            }

            extensionFilesName[extensionFile].Add(fileName);
        }
    }
}