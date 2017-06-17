using System;
using System.Collections.Generic;
using System.Linq;

class Batteries
{
    static void Main()
    {
        double[] capacities = ReadLine();
        double[] usagePerHour = ReadLine();
        int hour = int.Parse(Console.ReadLine());

        PrintStatusBattery(GetStatusBattery(capacities, usagePerHour, hour));

    }

    static List<string> GetStatusBattery(double[] capacities, double[] usagePerHour, int hour)
    {
        List<string> statusBatt = new List<string>(capacities.Length);
        double result = 0d;

        for (int i = 0; i < capacities.Length; i++)
        {
            result = capacities[i] - (hour * usagePerHour[i]);

            if (result > 0)
            {
                double percent = ((double)result / (double)capacities[i]) * 100d;
                statusBatt.Add($"Battery {i + 1}: {result:F2} mAh ({percent:F2})%");
            }
            else
            {
                double howManyHours = Math.Ceiling(capacities[i] / usagePerHour[i]);
                statusBatt.Add($"Battery {i + 1}: dead (lasted {howManyHours} hours)");
            }            
        }

        return statusBatt;
    }

    static void PrintStatusBattery(List<string> statusBattery)
    {
        statusBattery.ForEach(Console.WriteLine);
    }

    static double[] ReadLine()
    {
        double[] readLine = Console.ReadLine()
            .Split(' ')
            .Select(double.Parse)
            .ToArray();

        return readLine;
    }
}