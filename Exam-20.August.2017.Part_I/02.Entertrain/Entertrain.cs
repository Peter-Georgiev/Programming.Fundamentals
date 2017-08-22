using System;
using System.Collections.Generic;
using System.Linq;

class Entertrain
{
    static void Main()
    {
        List<int> arr = new List<int>();
        int locomotivesPower = int.Parse(Console.ReadLine());

        while (true)
        {
            string readLine = Console.ReadLine();
            if (readLine == "All ofboard!")
            {
                break;
            }

            arr.Add(int.Parse(readLine));

            int sum = arr.Sum();
            while (sum > locomotivesPower)
            {
                int average = (int)Math.Truncate((decimal)sum / arr.Count);

                int closest = arr[0];
                for (int i = 0; i < arr.Count; ++i)
                {
                    if (Math.Abs(arr[i] - average) < Math.Abs(closest - average))
                    {
                        closest = arr[i];
                    }
                }

                arr.Remove(closest);
                
                sum = arr.Sum();
            }
        }
        arr.Reverse();
        Console.WriteLine(String.Join(" ", arr) + " " + locomotivesPower);
    }
}