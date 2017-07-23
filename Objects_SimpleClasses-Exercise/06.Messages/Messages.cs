using System;
using System.Collections.Generic;
using System.Linq;

class User
{
    public string Username { get; set; }

    public List<Message> Messages { get; set; }
    
    public User(string username) //Конструкрот
    {   //this - за яснота
        this.Username = username;
        this.Messages = new List<Message>();
    }
}

class Message
{
    public string Content { get; set; }

    public User Sender { get; set; }

    public Message(string content, User sender)
    {
        this.Content = content;
        this.Sender = sender;
    }
}

class Messages
{
    static void Main()
    {
        var user = new Dictionary<string, User>();
        string sender = String.Empty;
        string recipient = String.Empty;

        string input = Console.ReadLine();
        while (!input.Equals("exit"))
        {
            string[] inputTokens = input.Split(' ');
            
            if (inputTokens[0].Equals("register"))
            {
                string username = inputTokens[1];
                user.Add(username, new User(username));
            }
            else
            {
                sender = inputTokens[0];
                recipient = inputTokens[2];
                string content = inputTokens[3];

                if (user.ContainsKey(sender) && user.ContainsKey(recipient))
                {
                    User senderUser = user[sender];
                    user[recipient].Messages.Add(new Message(content, senderUser));
                }
            }

            input = Console.ReadLine();
        }

        string[] chatTokens = Console.ReadLine().Split(' ');
        sender = chatTokens[0];
        recipient = chatTokens[1];

        Message[] senderMessages = user[recipient].Messages
            .Where(m => m.Sender.Username.Equals(sender))
            .ToArray();

        Message[] recipientMessages = user[sender].Messages
            .Where(m => m.Sender.Username.Equals(recipient))
            .ToArray();

        if (senderMessages.Length == 0 && recipientMessages.Length == 0)
        {
            Console.WriteLine("No messages");
        }

        int index = 0;
        while (index < senderMessages.Length && index < recipientMessages.Length)
        {
            PrintSender(sender, senderMessages, index);
            PrintReceipient(recipient, recipientMessages, index);

            index++;
        }

        while (index < senderMessages.Length)
        {
            PrintSender(sender, senderMessages, index);

            index++;
        }

        while (index < recipientMessages.Length)
        {
            PrintReceipient(recipient, recipientMessages, index);

            index++;
        }
    }

    private static void PrintReceipient(string recipient, Message[] recipientMessages, int index)
    {
        Console.WriteLine($"{recipientMessages[index].Content} :{recipient}");
    }

    private static void PrintSender(string sender, Message[] senderMessages, int index)
    {
        Console.WriteLine($"{sender}: {senderMessages[index].Content}");
    }
}