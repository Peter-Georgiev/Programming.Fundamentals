using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SinoTheWalker
{
    static void Main()
    {
        int[] time = Console.ReadLine() //HH:mm:ss
            .Split(':')
            .Select(int.Parse)
            .ToArray();

        long secondsTime = (60 * 60 * time[0]) + (60 * time[1]) + time[2];

        long secondsToAdd =
            (long)int.Parse(Console.ReadLine()) *
            (long)int.Parse(Console.ReadLine());

        secondsTime = secondsTime + secondsToAdd;

        long second = secondsTime % 60;
        long min = 


    }
}