using System;
class CenturiesToMinutes
{
    static void Main()
    {
        byte centuries = byte.Parse(Console.ReadLine());

        int years = centuries * 100;
        double days = years * 365.2422d;
        int hours = (int)days * 24;
        int minutes = hours * 60;
        Console.WriteLine($"{centuries} centuries = {years} years = {Convert.ToInt64(days)} days = {hours} hours = {minutes} minutes");
        
    }
}