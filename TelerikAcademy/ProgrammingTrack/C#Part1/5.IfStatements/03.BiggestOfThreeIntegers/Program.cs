using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BiggestOfThreeIntegers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the first integer.");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second integer.");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second integer.");
            int c = int.Parse(Console.ReadLine());
            int biggest;
            if (a > b)
            {
                if (a > c)
                {
                    biggest = a;
                }
                else
                {
                    biggest = c;
                }
            }
            else
            {
                if (b > c)
                {
                    biggest = b;
                }
                else
                {
                    biggest = c;
                }
            }
           Console.WriteLine(biggest);

        }
    }
}
