using System;
using System.Collections.Generic;
using System.Linq;

class DeserializeString
{
    static void Main()
    {
        SortedDictionary<int, char> result = new SortedDictionary<int, char>();
        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("end"))
            {
                break;
            }

            string[] tokens = command
                .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int[] indices = tokens[1]
                .Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char ch = Convert.ToChar(tokens[0]);
                        
            for (int i = 0; i < indices.Length; i++)
            {
                if (!result.ContainsKey(indices[i]))
                {
                    result.Add(indices[i], ch);
                }
            }            
        }

        result
            .Select(x => x.Value)
            .ToList()
            .ForEach(x => Console.Write(x));
        Console.WriteLine();
    }
}