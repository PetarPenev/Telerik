using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumOf3Numbers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the first number.");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second number.");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the third number.");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(a + b + c);
        }
    }
}
