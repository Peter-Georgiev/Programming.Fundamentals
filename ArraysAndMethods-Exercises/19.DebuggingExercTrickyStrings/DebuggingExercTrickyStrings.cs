using System;

class DebuggingExercTrickyStrings
{
    static void Main()
    {
        var delimiter = Console.ReadLine();
        var numberOfStrings = int.Parse(Console.ReadLine());
        
        var result = string.Empty;
        var currentString = string.Empty;

        for (int i = 0; i < numberOfStrings; i++)
        {
            currentString = Console.ReadLine();

            result += currentString;

            if (i < numberOfStrings - 1)
            {
                result += delimiter;
            }
        }

        Console.WriteLine(result);
    }
}