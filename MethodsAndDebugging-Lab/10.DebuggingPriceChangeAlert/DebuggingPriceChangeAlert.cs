using System;

class DebuggingPriceChangeAlert
{
    static void Main()
    {
        int numberOfpricesFirst = int.Parse(Console.ReadLine());
        double significanceThreshold = double.Parse(Console.ReadLine());
        double pricesFirst = double.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfpricesFirst - 1; i++)
        {
            double priceLast = double.Parse(Console.ReadLine());
            double div = DivPriceFirstAndLast(pricesFirst, priceLast);

            bool isSignificantDifference = GetSignificantDifference(div, significanceThreshold);            
            string message = GetMessage(priceLast, pricesFirst, div, isSignificantDifference);
            pricesFirst = priceLast;

            Console.WriteLine(message);            
        }
    }

    private static string GetMessage(double priceLast, double pricesFirst, double difference, bool isTrueOrFalse)
    {
        string message = "";
        difference *= 100;
        if (difference == 0)
        {
            message = string.Format("NO CHANGE: {0}", priceLast);
        }
        else if (!isTrueOrFalse)
        {
            message = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", pricesFirst, priceLast, difference);
        }
        else if (isTrueOrFalse && (difference > 0))
        {
            message = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", pricesFirst, priceLast, difference);
        }
        else if (isTrueOrFalse && (difference < 0))
        {
            message = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", pricesFirst, priceLast, difference);
        }

        return message;
    }

    private static bool GetSignificantDifference(double div, double significanceThreshold)
    {
        if (Math.Abs(div) >= significanceThreshold)
        {
            return true;
        }

        return false;
    }

    private static double DivPriceFirstAndLast(double pricesFirst, double priceLast)
    {
        double r = (priceLast - pricesFirst) / pricesFirst;
        return r;
    }
}