using System;

/* Write a program that generates and prints to the console 10 random values in the range [100, 200]. */
namespace _02.TenRandomNumbers
{
    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            int num=0;
            for (int i = 0; i < 9; i++)
            {
                num = rand.Next(100, 201);
                Console.Write("{0},", num);
            }
            num = rand.Next(100, 201);
            Console.WriteLine(num);
        }
    }
}
