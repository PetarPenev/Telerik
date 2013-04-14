using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.RealRoots
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
            double disc = b*b - 4 * a * c;
            double root1,root2;
            if (disc < 0)
            {
                Console.WriteLine("0 real roots");
            }
            else if (disc==0)
            {
                root1=-b/(2*a);
                Console.WriteLine("The real root is {0}",root1);
            }
            else
            {
                root1=(-b+Math.Sqrt(disc))/(2*a);
                root2=(-b-Math.Sqrt(disc))/(2*a);
                Console.WriteLine("The real roots are {0} and {1}",root1,root2);
            }
        }
    }
}
