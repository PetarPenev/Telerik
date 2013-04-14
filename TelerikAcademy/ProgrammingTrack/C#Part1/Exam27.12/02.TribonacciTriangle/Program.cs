using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TribonacciTriangle
{
    class Program
    {
        static void Main()
        {
            long fib1, fib2, fib3,intFib;
            byte l;
            fib1 = long.Parse(Console.ReadLine());
            fib2 = long.Parse(Console.ReadLine());
            fib3 = long.Parse(Console.ReadLine());
            l = byte.Parse(Console.ReadLine());
            Console.WriteLine(fib1);
            Console.WriteLine(fib2+" "+fib3);
            for (int i = 3; i <= l; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (j != 0)
                        Console.Write(" ");
                    intFib = fib1 + fib2 + fib3;
                    Console.Write(intFib);
                    fib1 = fib2;
                    fib2 = fib3;
                    fib3 = intFib;
                }
                Console.WriteLine();
            }


        }
    }
}
