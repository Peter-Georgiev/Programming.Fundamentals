using System;
using System.Linq;

class Phone
{
    static void Main()
    {
        string[] phoneNumbers = Console.ReadLine().Split(' ').ToArray();
        string[] phoneNames = Console.ReadLine().Split(' ').ToArray();

        while (true)
        {
            string[] commant = Console.ReadLine().Split(' ').ToArray();

            if (commant[0].Equals("done"))
            {
                break;
            }

            string nameOrNumbers = string.Empty;
            string numbers = string.Empty;
            string names = string.Empty;

            for (int j = 0; j < phoneNumbers.Length; j++)
            {
                if (commant[1] == phoneNumbers[j])
                {
                    names = phoneNames[j];
                    numbers = phoneNumbers[j];
                    nameOrNumbers = "numbers";
                    break;
                }
            }

            for (int j = 0; j < phoneNames.Length; j++)
            {
                if (commant[1] == phoneNames[j])
                {
                    names = phoneNames[j];
                    numbers = phoneNumbers[j];
                    nameOrNumbers = "names";
                    break;
                }
            }

            int sumOfDigits = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int x = 0;
                Int32.TryParse($"{numbers[i]}", out x);
                sumOfDigits += x;
            }

            if (commant[0].Equals("call") && !nameOrNumbers.Equals(""))
            {

                Console.WriteLine($"calling {PrintNamesOrNumbers(nameOrNumbers, numbers, names)}...");

                if (sumOfDigits % 2 == 0)
                {
                    int mm = sumOfDigits / 60;
                    int ss = sumOfDigits % 60;
                    Console.WriteLine($"call ended. duration: {mm:D2}:{ss:D2}");
                }
                else
                {
                    Console.WriteLine("no answer");
                }
            }
            else if (commant[0].Equals("message") && !nameOrNumbers.Equals(""))
            {
                Console.WriteLine($"sending sms to {PrintNamesOrNumbers(nameOrNumbers, numbers, names)}...");

                if (sumOfDigits % 2 == 0)
                {
                    Console.WriteLine("meet me there");
                }
                else
                {
                    Console.WriteLine("busy");
                }
            }
        }
    }

    private static string PrintNamesOrNumbers(string nameOrNumbers, string numbers, string names)
    {

        if (nameOrNumbers.Equals("names"))
        {
            return numbers;
        }
        else
        {
            return names;
        }
    }
}