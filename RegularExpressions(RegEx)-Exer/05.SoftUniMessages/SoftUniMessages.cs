using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Messages
{
    public string Message { get; set; }

    public string VerificationCode { get; set; }

    public Messages(string message, string verificationCode)
    {
        this.Message = message;
        this.VerificationCode = verificationCode;
    }
}

class SoftUniMessages
{
    static void Main()
    {
        List<Messages> messages = new List<Messages>();

        InsertMessage(messages);

        PrintMessages(messages);
    }

    static void InsertMessage(List<Messages> messages)
    {
        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("Decrypt!"))
            {
                break;
            }

            int m = int.Parse(Console.ReadLine());

            Match regex = Regex.Match(readLine, $@"(?<befor>^\d+)(?<message>[A-Za-z]{{{m}}})(?<after>[^A-Za-z]+$)");
            if (!regex.Success)
            {
                continue;
            }

            string message = regex.Groups["message"].Value.Trim();

            string befor = regex.Groups["befor"].Value;
            string after = regex.Groups["after"].Value;

            int[] indexes = String.Concat(befor, after)
                .Where(Char.IsDigit)
                .Select(x => x - '0')
                .ToArray();

            StringBuilder verificationCode = new StringBuilder();

            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];
                if (index >= message.Length)
                {
                    continue;
                }

                verificationCode.Append(message[index]);
            }

            messages.Add(new Messages(message, verificationCode.ToString()));
        }
    }

    static void PrintMessages(List<Messages> messages)
    {
        foreach (var m in messages)
        {
            Console.WriteLine($"{m.Message} = {m.VerificationCode}");
        }
    }
}