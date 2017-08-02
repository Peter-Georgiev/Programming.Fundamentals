using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FootballLeague
{
    static void Main()
    {
        string key = Console.ReadLine();

        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("final"))
            {
                break;
            }

            string pattern = @"(?<name>\w+).*?";
            pattern =  pattern.Insert(8, key);
            pattern = pattern.Insert(11 + key.Length, key);

            Console.WriteLine(pattern);


        }
    }
}