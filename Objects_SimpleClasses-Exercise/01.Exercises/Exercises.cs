//using ClassExercise;
using System;
using System.Collections.Generic;
using System.Linq;

class Exercise
{
    public string Topic { get; set; }

    public string CourseName { get; set; }

    public string JudgeContestLink { get; set; }

    public List<string> Problems { get; set; }
}

class Exercises
{
    static void Main()
    {
        List<Exercise> exercises = new List<Exercise>();

        while (true)
        {
            string readLine = Console.ReadLine();

            if (readLine.Equals("go go go"))
            {
                break;
            }
            else
            {
                InsertExercises(exercises, readLine);
            }
        }

        PrintExercise(exercises);
    }

    private static void InsertExercises(List<Exercise> exercises, string readLine)
    {
        string[] inputs = readLine
                            .Split(" ->,".ToCharArray(),
                            StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

        string topic = inputs[0];
        string courseName = inputs[1];
        string judgeContestLink = inputs[2];
        List<string> problems = inputs.Skip(3).ToList();

        Exercise newExercise = new Exercise
        {
            Topic = topic,
            CourseName = courseName,
            JudgeContestLink = judgeContestLink,
            Problems = problems
        };

        exercises.Add(newExercise);
    }

    private static void PrintExercise(List<Exercise> exercises)
    {
        foreach (var print in exercises)
        {
            byte count = 1;

            Console.WriteLine($"Exercises: {print.Topic}");
            Console.WriteLine($"Problems for exercises and homework for the " +
                $"\"{print.CourseName }\" course @ SoftUni.");
            Console.WriteLine($"Check your solutions here: {print.JudgeContestLink}");

            foreach (var printProblem in print.Problems)
            {
                Console.WriteLine($"{count++}. {printProblem}");
            }
        }
    }
}