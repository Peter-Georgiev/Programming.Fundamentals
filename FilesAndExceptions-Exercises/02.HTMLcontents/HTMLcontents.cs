using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

class HTMLcontents
{
    static void Main()
    {
        string[] contents = new string[]
        {
            "<!DOCTYPE html>" + Environment.NewLine,
             "<html>" + Environment.NewLine,
             "<head>" + Environment.NewLine,
             "</head>" + Environment.NewLine,
             "<body>" + Environment.NewLine,
             "</body>" + Environment.NewLine,
             "</html>" + Environment.NewLine
        };

        var input = new Dictionary<string, List<string>>();

        ReadInputLine(input);

        WriteIndexFile(input, contents);
    }

    private static void WriteIndexFile(Dictionary<string, List<string>> input, string[] contents)
    {
        string indexFile = "index.html";

        List<string> body = new List<string>();
        string[] head = new string[3];
        head[0] = contents[2];
        head[2] = contents[3];
        
        foreach (KeyValuePair<string, List<string>> kvp in input)
        {
            string tag = kvp.Key;

            if (tag.Equals("title"))
            {
                string[] content = kvp.Value.ToArray();

                head[1] = $"\t<title>{content[content.Length - 1]}</title>" +
                    Environment.NewLine;
            }
            else
            {
                foreach (var content in kvp.Value)
                {
                    body.Add($"\t<{tag}>{content}</{tag}>" + Environment.NewLine);
                }
            }
        }

        File.Delete(indexFile);

        File.AppendAllText(indexFile, contents[0]);
        File.AppendAllText(indexFile, contents[1]);
        
        foreach (var item in head)
        {
            File.AppendAllText(indexFile, item);
        }

        foreach (var item in body)
        {
            File.AppendAllText(indexFile, item);
        }

        File.AppendAllText(indexFile, contents[6]);
    }

    static void ReadInputLine(Dictionary<string, List<string>> input)
    {

        while (true)
        {
            string[] tokens = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string tag = tokens[0];

            if (tag.Equals("exit"))
            {
                break;
            }

            string content = tokens[1];

            if (!input.ContainsKey(tag))
            {
                input.Add(tag, new List<string>());
            }

            input[tag].Add(content);            
        }
    }
}