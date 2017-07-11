using System.Linq;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        string[] inputLines = File.ReadAllLines("input.txt");

        byte count = 1;

        string[] outputLines = inputLines
            .Select(x => $"{count++}. " + x).ToArray();
                
        File.WriteAllLines("output.txt", outputLines);
    }
}