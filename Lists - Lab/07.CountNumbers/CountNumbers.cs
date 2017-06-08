using System;
using System.Collections.Generic;
using System.Linq;

class CountNumbers
{
    static void Main()
    {
        List<int> countInput = new List<int>(1001);
        countInput = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        Dictionary<int, int> countPrint = new Dictionary<int, int>();        

        for (int i = 0; i < countInput.Count; i++)
        {
            byte count = 0;
            for (int j = 0; j < countInput.Count; j++)
            {
                if ((int)countInput[i] == (int)countInput[j])
                {
                    count++;
                }
            }            

            if (!countPrint.ContainsKey(countInput[i]))
            {
                countPrint.Add(countInput[i], count);
            }
        }

        List<int> listSort = countPrint.Keys.ToList();
        listSort.Sort();

        foreach (var key in listSort)
        {
            Console.WriteLine($"{key} -> {countPrint[key]}");
        }
    }
}