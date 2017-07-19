using System;
using System.Linq;
using System.Collections.Generic;

class Stateless
{
    static void Main()
    {
        List<string> result = new List<string>();
        
        while (true)
        {
            string states = Console.ReadLine().Trim();
            if (states.Equals("collapse"))
            {
                break;
            }
            string finction = Console.ReadLine().Trim();


            RemovingElementFinctionAndStates(states, finction, result);
        }

        PrintResult(result);
    }

    private static void PrintResult(List<string> result)
    {
        foreach (var print in result)
        {
            Console.WriteLine(print);
        }
    }

    private static void RemovingElementFinctionAndStates(string states, string finction, List<string> result)
    {
        while (true)
        {
            if (states.Contains(finction) && finction.Length > 0)
            {
                string tempStates = states.Replace(finction, "");
                states = tempStates;
            }
            else if (finction.Length > 0)
            {
                string tempFinction = finction.Remove(0, 1);
                if (tempFinction.Length > 0)
                {
                    finction = tempFinction.Remove(tempFinction.Length - 1, 1);
                }
                else
                {
                    finction = tempFinction;
                }
            }
            else
            {
                if (states.Length > 0)
                {
                    result.Add(states.Trim());
                }
                else
                {
                    result.Add("(void)");
                }
                break;
            }
        }
    }
}