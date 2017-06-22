using System;
using System.Collections.Generic;
using System.Linq;

class AverageStudentGrades
{
    static void Main()
    {
        var studentBook = new Dictionary<string, List<double>>();
        

        var readLine = Console.ReadLine();
        byte.TryParse(readLine, out byte count);

        for (int i = 0; i < count; i++)
        {
            readLine = Console.ReadLine();
            var tokens = readLine.Split(' ').ToArray();
            var name = tokens[0];
            var grade = double.Parse(tokens[1]);

            if (!studentBook.ContainsKey(name))
            {
                studentBook.Add(name, new List<double>() { grade });
            }
            else
            {
                studentBook[name].Add(grade);
            }
        }

        foreach (var pair in studentBook)
        {
            Console.Write($"{pair.Key} -> ");

            foreach (var studentGrades in pair.Value)
            {
                Console.Write($"{studentGrades:F2} ");
            }

            Console.WriteLine($"(avg: {pair.Value.Average():F2})");
        }
    }
}