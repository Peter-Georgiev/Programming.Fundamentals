using System;
using System.Linq;

class DataOverflow
{
    static void Main()
    {
        ulong[] dataType = new ulong[] {byte.MaxValue, ushort.MaxValue, uint.MaxValue, ulong.MaxValue};
        string[] message = new string[3];
        int count = 2;
        ulong[] inNum = new ulong[2];

        for (int i = 0; i < inNum.Length; i++)
        {
            inNum[i] = ulong.Parse(Console.ReadLine());
        }       

        while (count > 0)
        {
            string type = "";
            ulong checkNum;           

            if (count.Equals(2))
            {
                checkNum = inNum.Max();
            }
            else
            {
                checkNum = inNum.Min();
            }

            int data;
            for (data = 0; data < dataType.Length; data++)
            {
                if (checkNum <= dataType[data])
                {
                    switch (data)
                    {
                        case 0:
                            type = "byte";
                            break;
                        case 1:
                            type = "ushort";
                            break;
                        case 2:
                            type = "uint";
                            break;
                        case 3:
                            type = "ulong";
                            break;
                    }
                    break;
                }
            }

            if (count.Equals(2))
            {
                message[0] = $"bigger type: {type}";                
            }
            else
            {
                message[1] = $"smaller type: {type}";
                message[2] = $"{inNum.Max()} can overflow {type} " +
                    $"{Math.Round((decimal)inNum.Max() / (decimal)dataType[data])} times";                
            }

            count--;
        }

        for (int i = 0; i < message.Length; i++)
        {
            Console.WriteLine(message[i]);
        }
    }
}