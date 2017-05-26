using System;

class DNAsequences
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int newLine = 0;

        for (int n1 = 'A'; n1 <= 'T'; n1++)
        {            
            for (int n2 = 'A'; n2 <= 'T'; n2++)
            {                
                for (int n3 = 'A'; n3 <= 'T'; n3++)
                {
                    bool isSumRangeRange
                        = (n1.Equals('A') || n1.Equals('C') || n1.Equals('G') || n1.Equals('T'))
                        && (n2.Equals('A') || n2.Equals('C') || n2.Equals('G') || n2.Equals('T'))
                        && (n3.Equals('A') || n3.Equals('C') || n3.Equals('G') || n3.Equals('T'));

                    if (isSumRangeRange)
                    {
                        int sumRange = SumRange(n1) + SumRange(n2) + SumRange(n3);

                        if (sumRange >= n)
                        {
                            Console.Write($"O{(char)n1}{(char)n2}{(char)n3}O ");
                            newLine++;
                        }
                        else
                        {
                            Console.Write($"X{(char)n1}{(char)n2}{(char)n3}X ");
                            newLine++;
                        }

                        if (newLine == 4)
                        {
                            Console.WriteLine();
                            newLine = 0;
                        }
                    }
                }
            }
        }
    }

    public static int SumRange(int n)
    {
        int value = 0;
        if (n.Equals('A'))
        {
            value = 1;
        }
        else if (n.Equals('C'))
        {
            value = 2;
        }
        else if (n.Equals('G'))
        {
            value = 3;
        }
        else if (n.Equals('T'))
        {
            value = 4;
        }

        return value;
    }
}