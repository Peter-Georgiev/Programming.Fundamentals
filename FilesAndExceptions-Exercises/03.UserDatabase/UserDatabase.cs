using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class UserDatabase
{
    static void Main()
    {
        var database = new Dictionary<string, string>();

        ReadLineandInsertDatabase(database);
    }

    private static void ReadLineandInsertDatabase(Dictionary<string, string> database)
    {
        while (true)
        {
            string[] tokens = ReadLine();
            string command = tokens[0];

            if (command.Equals("exit"))
            {
                break;
            }

            if (command.Equals("register"))
            {
                string userName = tokens[1];

                if (!database.ContainsKey(userName))
                {
                    database.Add(userName, String.Empty);

                    bool isPassword = true;
                    while (isPassword)
                    {
                        if (tokens[2] == tokens[3])
                        {
                            database[userName] = tokens[2];
                            isPassword = false;
                        }
                        else
                        {
                            Console.WriteLine("The two passwords must match.");
                        }

                        tokens = ReadLine();
                        command = tokens[0];
                    }
                }
                else
                {
                    Console.WriteLine("The given username already exists.");
                }
            }

            bool login = command.Equals("login");

            while (login)
            {








                if (command.Equals("logout"))
                {
                    login = false;
                    break;
                }

                tokens = ReadLine();
                command = tokens[0];
            }
        }
    }

    static string[] ReadLine()
    {
        string[] tokens = Console.ReadLine()
                .Split(' ')
                .ToArray();
        return tokens;
    }
}