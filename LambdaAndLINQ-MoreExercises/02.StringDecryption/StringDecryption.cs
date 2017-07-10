using System;
using System.Collections.Generic;
using System.Linq;

class StringDecryption
{
    static void Main()
    {
        int[] command = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        List<int> decryption = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        decryption
            .Where(x => x >= 65 && x <= 90)
            .Skip(command[0])
            .Take(command[1])
            .ToList()
            .ForEach(x => Console.Write(Convert.ToChar(x)));
    }
}