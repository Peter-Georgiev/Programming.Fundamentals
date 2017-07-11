using System.IO;
using System.Linq;

class OddLines
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");
        
        var oddLines = lines
            .Where((line, index) => index % 2 != 0);

        
        File.WriteAllLines("output.txt", oddLines);
    }
}