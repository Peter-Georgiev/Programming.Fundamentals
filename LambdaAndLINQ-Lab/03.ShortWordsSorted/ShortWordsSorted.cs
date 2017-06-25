using System;
using System.Linq;

class ShortWordsSorted
{
    static void Main()
    {
        var words = Console.ReadLine()
            .Split(".,:;()[]\"\'\\/!? ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Where(w => w.Length < 5)
            .Select(w => w.ToLower())
            .OrderBy(w => w)
            .Distinct()
            .ToArray();

        Console.WriteLine(string.Join(", ", words));
    }
}