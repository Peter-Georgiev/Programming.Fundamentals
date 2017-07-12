using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class UserDatabase
{
    static void Main()
    {
        var database = new Dictionary<string, string>();

        string userFile = "user.txt";
        ReadUserFile(database, userFile);

        bool isExit = true;
        while (isExit)
        {
            string[] tokens = ReadLine();
            string command = tokens[0].ToLower();

            if (command.ToLower().Equals("exit"))
            {
                break;
            }

            RegisterUser(database, tokens);

            LoginAndLogout(database, tokens, ref isExit);

            NoUserDatabase(database, tokens);
        }

        WriteDatabaseFile(database, userFile);
    }

    private static void ReadUserFile(Dictionary<string, string> database, string userFile)
    {
        if (File.Exists(userFile))
        {
            string[] tokens = File.ReadAllText(userFile)
                .Split(new[] { '\'', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (tokens.Length > 0 && tokens.Length % 2 == 0)
            {
                for (int i = 0; i < tokens.Length - 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (!database.ContainsKey(tokens[i]))
                        {
                            database.Add(tokens[i], tokens[i + 1]);
                        }
                    }                    
                }
            }
        }
    }

    private static void WriteDatabaseFile(Dictionary<string, string> database, string userFile)
    {
        if (File.Exists(userFile))
        {
            File.Delete(userFile);
        }

        foreach (var kvp in database)
        {
            string userPass = $"'{kvp.Key}'\t'{kvp.Value}'" + Environment.NewLine;
            File.AppendAllText(userFile, userPass);
        }
    }

    private static void NoUserDatabase(Dictionary<string, string> database, string[] tokens)
    {
        string command = tokens[0].ToLower();
        if (database == null)
        {
            Console.WriteLine("There is no currently logged in user.");
        }        
    }

    private static void LoginAndLogout(Dictionary<string, string> database, string[] tokens, ref bool isExit)
    {
        string command = tokens[0].ToLower();
        bool hasLogin = command.ToLower().Equals("login") && database != null;

        if (hasLogin)
        {
            string userName = tokens[1];
            string password = tokens[2];

            bool hasUserName = false;
            bool hasUserPass = false;

            if (database.ContainsKey(userName))
            {
                hasUserName = true;
                foreach (var kvp in database)
                {
                    if (kvp.Key == userName)
                    {
                        if (kvp.Value == password)
                        {
                            hasUserPass = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The password you entered is incorrect.");
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no user with the given username.");
            }

            while (hasUserName && hasUserPass)
            {
                bool hasExitOrLogout =
                    command.ToLower().Equals("logout") || command.ToLower().Equals("exit");

                if (command.ToLower().Equals("exit"))
                {
                    isExit = false;
                }

                if (hasExitOrLogout)
                {                   
                    break;
                }

                tokens = ReadLine();
                command = tokens[0];
            }
        }
        else if (command.ToLower().Equals("logout"))
        {
            Console.WriteLine("There is no currently logged in user.");
        }
    }

    private static void RegisterUser(Dictionary<string, string> database, string[] tokens)
    {
        string command = tokens[0].ToLower();

        if (command.ToLower().Equals("register") && tokens.Length > 3)
        {
            string userName = tokens[1];

            if (!database.ContainsKey(userName))
            {
                if (tokens[2] == tokens[3])
                {
                    database.Add(userName, String.Empty);
                    database[userName] = tokens[2];
                }
                else
                {
                    Console.WriteLine("The two passwords must match.");                    
                }
            }
            else
            {
                Console.WriteLine("The given username already exists.");
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