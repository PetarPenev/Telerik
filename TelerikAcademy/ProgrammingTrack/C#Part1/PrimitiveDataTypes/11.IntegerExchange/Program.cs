using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.IntegerExchange
{
    class Program
    {
        static void Main()
        {
            int a, b;
            a=5;
            b=10;
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine("{0}, {1}", a, b);
        }
    }
}
