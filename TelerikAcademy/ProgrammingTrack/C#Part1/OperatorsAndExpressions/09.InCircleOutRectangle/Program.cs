using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.InCircleOutRectangle
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the first coordinate of the point.");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second coordinate of the point.");
            double y = double.Parse(Console.ReadLine());
            bool check = true;
            double d = Math.Sqrt(Math.Pow(x-1, 2) + Math.Pow(y-1, 2));
            if (d>3)
            {
                check = false;
            }
            if ((x>=-1) && (x<=5) && (y>=-1) && (y<=1))
            {
                check = false;
            }
            if (check == true)
            {
                Console.WriteLine("Yes, the point is in the circle and outside the rectangle.");
            }
            else
            {
                Console.WriteLine("No, the point is not in the circle and outside the triangle.");
            }
        }
    }
}
