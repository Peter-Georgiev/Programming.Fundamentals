using System;
using System.Collections.Generic;
using System.Linq;

class User
{
    public string Username { get; set; }

    public List<Message> ReceivedMessages { get; set; }
}

class Message
{
    public string Content { get; set; }

    public User Sender { get; set; }
}

class Messages
{
    static void Main()
    {
        var messages = new Dictionary<string, User>();

        ReadMessages(messages);

        PrintMessage(messages);
    }

    private static void PrintMessage(Dictionary<string, User> messages)
    {
        string[] tokens = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string firstUser = tokens[0];
        string secondUser = tokens[1];

        //messages
        //    .Where(x => x.Key == secondUser)
        //    .ToList()
        //    .ForEach()

        foreach (var kvp in messages)
        {
            if (kvp.Value.Username == firstUser)
            {
                    Console.Write($"{kvp.Value.Username}: ");
                foreach (var received in kvp.Value.ReceivedMessages)
                {
                    Console.WriteLine($"{received.Content} :{received.Sender}");
                }
            }
        }
        

    }

    private static void ReadMessages(Dictionary<string, User> messages)
    {
        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("exit"))
            {
                break;
            }

            string[] tokens = readLine
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string senderUsername = tokens[0];
            string register = tokens[0];
            string username = tokens[1];

            if (register.Equals("register"))
            {
                if (!messages.ContainsKey(username))
                {
                    messages.Add(username, new User());
                }
            }
            else if (tokens.Length < 2)
            {
            }
            else if (messages.ContainsKey(tokens[2]))
            {
                string send = tokens[1];
                string recipientUsername = tokens[2];
                string content = tokens[3];

                foreach (var kvp in messages)
                {
                    if (kvp.Key == recipientUsername)
                    {
                        foreach (var item in kvp.Value.Username)
                        {
                            kvp.Value.Username = recipientUsername;
                        }
                        foreach (var item in kvp.Value.ReceivedMessages)
                        {
                            item.Content = content;
                            item.Sender.Username = senderUsername;
                        }
                    }                  
                }
            }            
        }        
    }
}