using System;
using System.Collections.Generic;

class Notifications
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        List<string> showOutput = new List<string>(count * 3);

        while (count > 0)
        {
            string readLine = ReadOperation();
            

            if (readLine.Equals("success"))
            {
                showOutput.AddRange(ShowSuccess());
            }
            else if (readLine.Equals("error"))
            {
                showOutput.AddRange(ShowError());
            }

            count--;
        }

        PrintResult(showOutput);
    }

    static string ReadOperation()
    {
        string readOperation = Console.ReadLine();
        return readOperation;
    }
    
    static List<string> ShowSuccess()
    {
        List<string> showSuccess = new List<string>();

        showSuccess.Add($"Successfully executed {ReadOperation()}.");
        showSuccess.Add($"==============================");
        showSuccess.Add($"Message: {ReadOperation()}.");

        return showSuccess;
    }

    static List<string> ShowError()
    {
        List<string> showError = new List<string>();

        showError.Add($"Error: Failed to execute {ReadOperation()}.");
        showError.Add($"==============================");
        Int32.TryParse(ReadOperation(), out int x);
        showError.Add($"Error Code: {x}.");
        if (x >= 0)
        {
            showError.Add("Reason: Invalid Client Data.");
        }
        else
        {
            showError.Add("Reason: Internal System Failure.");
        }

        return showError;
    }

    static void PrintResult(List<string> showOutput)
    {
        showOutput.ForEach(Console.WriteLine);
    }
}