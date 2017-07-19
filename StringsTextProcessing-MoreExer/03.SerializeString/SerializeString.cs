using System;
using System.Collections.Generic;

class SerializeString
{
    static void Main()
    {
        string readLine = Console.ReadLine();

        List<char> input = new List<char>();
        for (int i = 0; i < readLine.Length; i++)
        {
            input.Add(readLine[i]);
        }

        List<string> result = new List<string>();

        for (int i = 0; i < input.Count; i++)
        {
            char ch = input[i];
            string chCount = String.Empty;
            List<int> count = new List<int>();
            bool isNewCh = true;

            for (int i2 = i; i2 < input.Count; i2++)
            {
                if (input[i2] == ch && !result.Contains(Convert.ToString(ch)))
                {
                    count.Add(i2);

                    if (isNewCh)
                    {
                        chCount = Convert.ToString(ch);
                    }
                    isNewCh = false;
                }
            }

            if (!isNewCh)
            {
                result.Add($"{chCount}");
                result.Add(":" + string.Join("/", count));
            }
        }

        for (int i = 0; i < result.Count; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(result[i]);
            }
            else
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}