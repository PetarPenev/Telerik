using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GreaterOfTwoNumbers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the first number.");
            decimal a = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second number.");
            decimal b = decimal.Parse(Console.ReadLine());
            Console.WriteLine(Math.Max(a, b));
        }
    }
}
