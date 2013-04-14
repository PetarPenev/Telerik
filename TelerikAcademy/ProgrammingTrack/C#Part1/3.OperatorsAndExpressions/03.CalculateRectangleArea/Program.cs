using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CalculateRectangleArea
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please Enter the Width of the Rectangle.");
            decimal width=decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the Heigh of the Rectangle.");
            decimal height = decimal.Parse(Console.ReadLine());
            decimal area = height * width;
            Console.WriteLine("The area of the rectangle is {0}.", area);
        }
    }
}
