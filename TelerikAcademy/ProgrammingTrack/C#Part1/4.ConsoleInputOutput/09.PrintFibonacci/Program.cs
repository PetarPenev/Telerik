using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PrintFibonacci
{
    class Program
    {
        static void Main()
        {
            decimal a = 0;
            decimal b = 1;
            Console.WriteLine(a);
            Console.WriteLine(b);
            for (int i = 1; i <= 98; i++)
            {
                b = a + b;
                a = b - a;
                Console.WriteLine(b);
            }
        }
    }
}
