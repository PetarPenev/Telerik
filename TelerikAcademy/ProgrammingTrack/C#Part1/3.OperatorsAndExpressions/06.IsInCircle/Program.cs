using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace _06.IsInCircle
{
    class Program
    {
        static void Main()
        {
            
            Console.WriteLine("Please enter the first coordinate.");
            double x=double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second coordinate.");
            double y=double.Parse(Console.ReadLine());
            double d=Math.Sqrt(Math.Pow(x,2)+Math.Pow(y,2));
            if (d<=5)
            {
                Console.WriteLine("The point is within the circle");
            }
            else
            {
                Console.WriteLine("The point is outside the circle.");
            }
        }
    }
}
