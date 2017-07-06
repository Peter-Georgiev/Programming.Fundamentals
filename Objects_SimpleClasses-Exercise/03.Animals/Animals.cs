using System;
using System.Collections.Generic;
using System.Linq;

class Dog
{
    public string Name { get; set; }

    public int Age { get; set; }

    public int NumberOfLegs { get; set; }

    public void ProduceSound()
    {
        Console.WriteLine("I'm a Distinguishedog, and I will now produce a distinguished sound! Bau Bau.");
    }
}

class Cat
{
    public string Name { get; set; }

    public int Age { get; set; }

    public int IntlligenceQuotient { get; set; }

    public void ProduceSound()
    {
        Console.WriteLine("I'm an Aristocat, and I will now produce an aristocratic sound! Myau Myau.");
    }
}

class Snake
{
    public string Name { get; set; }

    public int Age { get; set; }

    public int CrueltyCoefficient { get; set; }

    public void ProduceSound()
    {
        Console.WriteLine("I'm a Sophistisnake, and I will now produce a sophisticated sound! Honey, I'm home.");
    }
}


class Animals
{
    static void Main()
    {
        Dictionary<string, Dog> dogs = new Dictionary<string, Dog>();
        Dictionary<string, Cat> cats = new Dictionary<string, Cat>();
        Dictionary<string, Snake> snakes = new Dictionary<string, Snake>();

        while (true)
        {
            string readLine = Console.ReadLine();

            var t = readLine.Take(3).ToArray();

            if (readLine.Equals("I'm your Huckleberry"))
            {
                break;
            }
            else if (readLine.Substring(0, 3).Equals("Dog"))
            {
                InsertDog(dogs, readLine);
            }
            else if (readLine.Substring(0, 3).Equals("Cat"))
            {
                InsertCat(cats, readLine);
            }
            else if (readLine.Substring(0, 5).Equals("Snake"))
            {
                InsertSnake(snakes, readLine);
            }
            else if (readLine.Substring(0, 4).Equals("talk"))
            {
                PrintTalk(dogs, cats, snakes, readLine);
            }
        }
        
        PrintAnimals(dogs, cats, snakes);
    }

    private static void PrintAnimals(Dictionary<string, Dog> dogs, Dictionary<string, Cat> cats, Dictionary<string, Snake> snakes)
    {
        if (dogs != null)
        {
            dogs.Values
                .ToList()
                .ForEach(x => Console.WriteLine($"Dog: {x.Name}, Age: {x.Age}, Number Of Legs: {x.NumberOfLegs}"));
        }

        if (cats != null)
        {
            cats.Values
                .ToList()
                .ForEach(x => Console.WriteLine($"Cat: {x.Name}, Age: {x.Age}, IQ: {x.IntlligenceQuotient}"));
        }

        if (snakes != null)
        {
            snakes.Values
                .ToList()
                .ForEach(x => Console.WriteLine($"Snake: {x.Name}, Age: {x.Age}, Cruelty: {x.CrueltyCoefficient}"));
        }
    }

    static void PrintTalk(Dictionary<string, Dog> dogs, Dictionary<string, Cat> cats, Dictionary<string, Snake> snakes, string readLine)
    {
        string[] tokens = ReadLine(readLine);

        if (dogs.ContainsKey(tokens[1]))
        {
            dogs[tokens[1]].ProduceSound();
        }
        else if (cats.Keys.Contains(tokens[1]))
        {
            cats[tokens[1]].ProduceSound();
        }
        else if (snakes.ContainsKey(tokens[1]))
        {
            snakes[tokens[1]].ProduceSound();
        }
    }

    static void InsertSnake(Dictionary<string, Snake> snakes, string readLine)
    {
        string[] tokens = ReadLine(readLine);

        var readSnake = new Snake
        {
            Name = tokens[1],
            Age = int.Parse(tokens[2]),
            CrueltyCoefficient = int.Parse(tokens[3])
        };

        snakes.Add(readSnake.Name, readSnake);
    }

    static void InsertCat(Dictionary<string, Cat> cats, string readLine)
    {
        string[] tokens = ReadLine(readLine);

        var readCat = new Cat
        {
            Name = tokens[1],
            Age = int.Parse(tokens[2]),
            IntlligenceQuotient = int.Parse(tokens[3])
        };

        cats.Add(readCat.Name, readCat);
    }

    static void InsertDog(Dictionary<string, Dog> dogs, string readLine)
    {
        string[] tokens = ReadLine(readLine);

        var readDog = new Dog
        {
            Name = tokens[1],
            Age = int.Parse(tokens[2]),
            NumberOfLegs = int.Parse(tokens[3])
        };

        dogs.Add(readDog.Name, readDog);
    }

    static string[] ReadLine(string readLine)
    {
        string[] tokens = readLine
            .Split(' ')
            .ToArray();

        return tokens;
    }
}