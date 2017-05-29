using System;

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
        string symbol = "\u00A9";
        Console.WriteLine($"{symbol} SoftUni");        
    }

    public static void PrintReceipt()
    {
        PrintReceiptHeader();
        PrintReceiptBody();
        PrintReceiptFooter();
    }

}
