using System;

class TypeBoundaries
{
    static void Main()
    {
        string numberType = Console.ReadLine();
        
        string message = string.Empty;

        switch (numberType)
        {
            case "int":
                message = $"{int.MaxValue}\n{int.MinValue}";
                break;
            case "uint":
                message = $"{uint.MaxValue}\n{uint.MinValue}";
                break;
            case "long":
                message = $"{long.MaxValue}\n{long.MinValue}";
                break;
            case "byte":
                message = $"{byte.MaxValue}\n{byte.MinValue}";
                break;
            case "sbyte":
                message = $"{sbyte.MaxValue}\n{sbyte.MinValue}";
                break;
            default:
                break;
        }

        Console.WriteLine(message);
    }
}