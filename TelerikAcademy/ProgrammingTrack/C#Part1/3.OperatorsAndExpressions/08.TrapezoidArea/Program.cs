using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.TrapezoidArea
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the first side of the trapezoid");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second side of the trapezoid");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the height of the trapezoid");
            double h = double.Parse(Console.ReadLine());
            double area = ((a + b) / 2) * h;
            Console.WriteLine("The area of the trapezoid is {0}", area);
        }
    }
}
