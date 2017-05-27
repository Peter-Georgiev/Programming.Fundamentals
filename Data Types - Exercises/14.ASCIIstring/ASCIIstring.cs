using System;
using System.Text;

class ASCIIstring
{
    static void Main()
    {        
        int lineN = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < lineN; i++)
        {
            int n = int.Parse(Console.ReadLine());
            string ascii = Encoding.ASCII.GetString(new byte[] { Convert.ToByte(n) });
            Console.Write(ascii);
        }

        Console.WriteLine();
    }
}