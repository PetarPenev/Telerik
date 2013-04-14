using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _07.SumOfNFibbonacci
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter n.");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine(0);
            }
            else if (n == 2)
            {
                Console.WriteLine(1);
            }
            else if (n == 3)
            {
                Console.WriteLine(2);
            }
            else
            {
                int fib1 = 1;
                int fib2 = 1;
                BigInteger sum = 2;
                for (int i = 4; i <= n; i++)
                {
                    fib1 = fib1 + fib2;
                    fib2 = fib1 - fib2;
                    sum += fib1;
                }
                Console.WriteLine(sum);
            }
        }
    }
}
