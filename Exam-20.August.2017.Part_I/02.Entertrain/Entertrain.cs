using System;
using System.Collections.Generic;
using System.Linq;

class Entertrain
{
    static void Main()
    {
        List<long> arr = new List<long>();
        long locomotivesPower = long.Parse(Console.ReadLine());

        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine == "All ofboard!")
            {
                break;
            }

            arr.Add(long.Parse(readLine));

            for (long i = 0; i < arr.Count; i++)
            {
                long sum = arr.Sum();
                if (sum > 0 && sum > locomotivesPower)
                {
                    long average = (long)Math.Truncate((decimal)sum / arr.Count);
                    //long average = sum / arr.Count;
                    long closest = arr
                        .Aggregate((x, y) => Math.Abs(x - average) < Math.Abs(y - average) ? x : y);
                    arr.Remove(closest);
                    i--;
                }
            }
        }            

        arr.Reverse();
        if (arr.Count > 0)
        {
            Console.WriteLine(String.Join(" ", arr) + " " + locomotivesPower);
        }
        else
        {
            Console.WriteLine(locomotivesPower);
        }

    }
}