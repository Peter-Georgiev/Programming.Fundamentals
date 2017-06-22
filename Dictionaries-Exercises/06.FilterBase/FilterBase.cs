using System;
using System.Collections.Generic;

class FilterBase
{
    static void Main()
    {
        var nameAge = new Dictionary<string, int>();
        var nameSalary = new Dictionary<string, double>();
        var namePsition = new Dictionary<string, string>();

        var readLine = Console.ReadLine();

        WriteNameBook(nameAge, nameSalary, namePsition, readLine);

        readLine = Console.ReadLine();

        PrinResult(nameAge, nameSalary, namePsition, readLine);
    }

    private static void WriteNameBook(Dictionary<string, int> nameAge, Dictionary<string, double> nameSalary, Dictionary<string, string> namePsition, string readLine)
    {
        while (!readLine.Equals("filter base"))
        {
            var tokens = readLine.Split(
                ",/\\|()\";:?'!`~*+-->= ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];
            var parameter = tokens[1];

            if (int.TryParse(parameter, out int age))
            {
                if (!nameAge.ContainsKey(name))
                {
                    nameAge.Add(name, age);
                }
            }
            else if (double.TryParse(parameter, out double salary))
            {
                if (!nameSalary.ContainsKey(name))
                {
                    nameSalary.Add(name, salary);
                }
            }
            else
            {
                if (!namePsition.ContainsKey(name))
                {
                    namePsition.Add(name, parameter);
                }
            }

            readLine = Console.ReadLine();
        }
    }

    private static void PrinResult(Dictionary<string, int> nameAge, Dictionary<string, double> nameSalary, Dictionary<string, string> namePsition, string readLine)
    {
        switch (readLine)
        {
            case "Age":
                PrintEmployeeAge(nameAge);
                break;
            case "Salary":
                PrintEmployeeSalary(nameSalary);
                break;
            case "Position":
                PrintEmployeePosition(namePsition);
                break;
        }
    }

    static void PrintEmployeeAge(Dictionary<string, int> nameAge)
    {
        foreach (var prin in nameAge)
        {
            Console.WriteLine($"Name: {prin.Key}");
            Console.WriteLine($"Age: {prin.Value}");
            Console.WriteLine("====================");
        }
    }

    static void PrintEmployeeSalary(Dictionary<string, double> nameSalary)
    {
        foreach (var prin in nameSalary)
        {
            Console.WriteLine($"Name: {prin.Key}");
            Console.WriteLine($"Salary: {prin.Value:F2}");
            Console.WriteLine("====================");
        }
    }

    static void PrintEmployeePosition(Dictionary<string, string> namePositiony)
    {
        foreach (var prin in namePositiony)
        {
            Console.WriteLine($"Name: {prin.Key}");
            Console.WriteLine($"Position: {prin.Value}");
            Console.WriteLine("====================");
        }
    }
}