using System;
using System.Text;

class BlankReceipt
{
    static void Main()
    {
        PrintReceipt();
    }

    public static void PrintReceiptHeader()
    {
        Console.WriteLine("CASH RECEIPT");
        Console.WriteLine("------------------------------");
    }

    public static void PrintReceiptBody()
    {
        Console.WriteLine("Charged to____________________");
        Console.WriteLine("Received by___________________");
    }

    public static void PrintReceiptFooter()
    {
        Console.WriteLine("------------------------------");
        //char symbol = '\u00A9';
        int symbol = 169;
        Console.OutputEncoding = Encoding.Unicode;
        Console.WriteLine($"{(char)symbol} SoftUni");        
    }

    public static void PrintReceipt()
    {
        PrintReceiptHeader();
        PrintReceiptBody();
        PrintReceiptFooter();
    }

}
