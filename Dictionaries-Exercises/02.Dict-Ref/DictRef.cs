using System;
using System.Collections.Generic;

class DictRef
{
    static void Main()
    {
        var resultDict = new Dictionary<string, int>();
        var readLine = Console.ReadLine();

        while (!readLine.Equals("end"))
        {
            var tokens = readLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var firstElement = tokens[0];
            var lastElement = tokens[tokens.Length - 1];

            if (int.TryParse(lastElement, out int n))
            {
                resultDict[firstElement] = n;
            }
            else
            {
                if (resultDict.ContainsKey(lastElement))
                {
                    var resultDictValues = resultDict[lastElement];
                    resultDict[firstElement] = resultDictValues;
                } 
            }

            readLine = Console.ReadLine();
        }

        foreach (var print in resultDict)
        {
            Console.WriteLine($"{print.Key} === {print.Value}");
        }
    }
}