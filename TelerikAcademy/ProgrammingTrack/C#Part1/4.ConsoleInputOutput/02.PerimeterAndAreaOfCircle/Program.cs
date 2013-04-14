using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PerimeterAndAreaOfCircle
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the radius.");
            decimal r = decimal.Parse(Console.ReadLine());
            Console.WriteLine("The perimeter is {0} and the area is {1}.", (decimal)Math.PI * 2 * r, (decimal)Math.PI * r * r);
        }
    }
}
