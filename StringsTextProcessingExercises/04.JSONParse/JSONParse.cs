using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }

    public int Age { get; set; }

    public List<int> Grades { get; set; }
}

class JSONParse
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        ReadStudents(students);

        PrintStudents(students);
    }
    
    private static void PrintStudents(List<Student> students)
    {
        foreach (var item in students)
        {
            Console.Write($"{item.Name} : {item.Age} -> ");

            if (item.Grades.Count > 0)
            {
                Console.WriteLine(string.Join(", ", item.Grades));
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }

    private static void ReadStudents(List<Student> students)
    {
        string readLine = Console.ReadLine();

        string[] tokens = readLine
            .Split(new string[] { "[{", "}]", "},{", "{", "}" },
            StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        for (int i = 0; i < tokens.Length; i++)
        {
            string[] sentences = tokens[i]
                    .Split(new string[] { "name:", "\"", ",age:",",grades:[", "]" },
                        StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

            string name = sentences[0];
            int age = int.Parse(sentences[1]);
            List<int> greade = new List<int>();

            if (sentences.Length > 2)
            {
                string strGreade = sentences[2];

                greade = strGreade
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            }
            
            Student newStudent = new Student
            {
                Name = name,
                Age = age,
                Grades = greade,
            };

            students.Add(newStudent);
        }
    }
}