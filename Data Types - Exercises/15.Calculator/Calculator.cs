using System;

class Calculator
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        char oper = char.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        int result;
        switch (oper)
        {
            case '+':
                result = a + b;
                break;
            case '-':
                result = a - b;
                break;
            case '*':
                result = a * b;
                break;
            case '/':
                result = a / b;
                break;
            default:
                result = 0;
                break;
        }

        Console.WriteLine($"{a} {oper} {b} = {result}");
    }
}