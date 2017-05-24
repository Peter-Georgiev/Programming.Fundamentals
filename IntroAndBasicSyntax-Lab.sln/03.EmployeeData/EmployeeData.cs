using System;

class EmployeeData
{
    static void Main()
    {
        string firstName = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        int employeeID = int.Parse(Console.ReadLine());
        double monthlySalary = double.Parse(Console.ReadLine());

        Console.WriteLine($"Name: {firstName}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Employee ID: {employeeID:D8}");
        Console.WriteLine($"Salary: {monthlySalary:F2}");
    }
}