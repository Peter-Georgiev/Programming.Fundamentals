using System;

class NeighbourWars
{
    static void Main()
    {
        int attackPesho = int.Parse(Console.ReadLine());
        int attackGosho = int.Parse(Console.ReadLine());

        int pointPesho = 100;
        int pointGosho = 100;
        int round = 0;

        while (pointGosho > 0 && pointPesho > 0)
        {
            round++;
            pointGosho -= attackPesho;
            if (pointGosho > 0)
            {
                Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {pointGosho} health.");
            }
            else
            {
                break;
            }
            if (round % 3 == 0)
            {
                pointPesho += 10;
                pointGosho += 10;
            }

            round++;
            pointPesho -= attackGosho;
            if (pointPesho > 0)
            {
                Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {pointPesho} health.");
            }
            else
            {
                break;
            }
            if (round % 3 == 0)
            {
                pointPesho += 10;
                pointGosho += 10;
            }
        }

        if (pointGosho > 0)
        {
            Console.WriteLine($"Gosho won in {round}th round.");
        }
        else
        {
            Console.WriteLine($"Pesho won in {round}th round.");
        }

    }
}