using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class CubicMessages
{
    static void Main()
    {
        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine.Equals("Over!"))
            {
                break;
            }
            int lengthMessage = int.Parse(Console.ReadLine());

            Regex regex = 
                new Regex($@"(?<left>^\d+)(?<word>[A-Za-z]{{{lengthMessage}}})(?<right>[^A-Za-z]*$)");

            Match input = regex.Match(readLine);
            string message = input.Groups["word"].Value;             

            if (!input.Success)
            {
                continue;
            }

            string leftStr = input.Groups["left"].Value;
            string rightStr = input.Groups["right"].Value;
            
            int[] indexes = string.Concat(leftStr, rightStr)
                .Where(Char.IsDigit)
                .Select(x => x - '0')                
                .ToArray();

            StringBuilder result = new StringBuilder();

            foreach (var index in indexes)
            {                
                if (index < 0 || index >= message.Length)
                {
                    result.Append(' ');
                }
                else
                {
                    result.Append(message[index]);
                }
            }

            Console.WriteLine($"{message} == {result}");
        }
    }
}