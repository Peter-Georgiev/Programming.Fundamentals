using System;
using System.Linq;

class ArrayData
{
    static void Main()
    {
        var readLine = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();
        var command = Console.ReadLine();

        if (command.ToLower().Equals("max"))
        {
            var max = readLine
                .Where(x => x >= readLine.Average())
                .ToList()
                .Max();
            Console.WriteLine(max);
        }
        else if (command.ToLower().Equals("min"))
        {
            var min = readLine
                .Where(x => x >= readLine.Average())
                .ToList()
                .Min();
            Console.WriteLine(min);
        }
        else if (command.ToLower().Equals("all"))
        {
            readLine
                .OrderBy(x => x)
                .Where(x => x >= readLine.Average())
                .ToList()
                .ForEach(x => Console.Write(string.Format("{0} ", x)));
        }
    }
}