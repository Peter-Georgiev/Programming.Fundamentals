using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }

    public int Age { get; set; }

    public int[] Grades { get; set; }
}

class JSONstringify
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("stringify"))
            {
                break;
            }

            ReadStudents(students, readLine);

        }

        PrintStudents(students);
    }

    private static void PrintStudents(List<Student> students)
    {
        int i = students.Count;

        Console.Write("[");

        foreach (var item in students)
        {
            Console.Write("{" + $"name:\"{item.Name}\",age:{item.Age},grades:[");

            Console.Write(string.Join(", ", item.Grades) + "]}");

            if (i > 1)
            {
                Console.Write(",");
            }

            i--;
        }

        Console.WriteLine("]");
    }

    private static void ReadStudents(List<Student> students, string readLine)
    {
        string[] tokens = readLine
                    .Split(new char[] { ' ', ':', '-', '>', ',' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

        string name = tokens[0];
        int age = int.Parse(tokens[1]);
        int[] greade = tokens
            .Skip(2)
            .Select(int.Parse)
            .ToArray();

        Student newStudent = new Student
        {
            Name = name,
            Age = age,
            Grades = greade,
        };

        students.Add(newStudent);
    }
}