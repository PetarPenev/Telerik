using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ExchangeTwoIntegerValues
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the first integer number.");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second integer number.");
            int b = int.Parse(Console.ReadLine());
            if (a > b)
            {
                a = a + b;
                b = a - b;
                a = a - b;
            }
            Console.WriteLine("{0},{1}",a, b);

        }
    }
}
