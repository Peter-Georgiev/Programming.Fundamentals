using System;
using System.Collections.Generic;

class UserLogins
{
    static void Main()
    {
        var userBook = new Dictionary<string, string>();

        var readLine = Console.ReadLine();

        WriteUserAndPass(userBook, readLine);

        readLine = Console.ReadLine();
        byte count = 0;
        
        count = GetLoginUserAndPass(userBook, readLine, count);

        Console.WriteLine($"unsuccessful login attempts: {count}");
    }

    private static byte GetLoginUserAndPass(Dictionary<string, string> userBook, string readLine, byte count)
    {
        while (!readLine.Equals("end"))
        {
            var tokens = readLine.Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var user = tokens[0];
            var pass = tokens[1];

            bool isUserAndPass = userBook.ContainsKey(user) && userBook[user] == pass;

            if (isUserAndPass)
            {
                Console.WriteLine($"{user}: logged in successfully");
            }
            else
            {
                count++;
                Console.WriteLine($"{user}: login failed");
            }

            readLine = Console.ReadLine();
        }

        return count;
    }

    private static void WriteUserAndPass(Dictionary<string, string> userBook, string readLine)
    {
        while (!readLine.Equals("login"))
        {
            var tokens = readLine.Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var user = tokens[0];
            var pass = tokens[1];

            if (!userBook.ContainsKey(user))
            {
                userBook.Add(user, pass);
            }
            else
            {
                userBook[user] = pass;
            }

            readLine = Console.ReadLine();
        }
    }
}