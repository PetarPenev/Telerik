using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SolvingQuadraticEquation
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter a.");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter b.");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter c.");
            double c = double.Parse(Console.ReadLine());
            double discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                Console.WriteLine("No real roots.");
            }
            if (discriminant == 0)
            {
                Console.WriteLine(-b / (2 * a));
            }
            if (discriminant > 0)
            {
                Console.WriteLine("{0} and {1}", (-b + Math.Sqrt(discriminant)) / (2 * a), (-b - Math.Sqrt(discriminant)) / (2 * a));
            }
        }
    }
}
