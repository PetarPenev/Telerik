using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SortThreeRealNumbers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the first real number.");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second real number.");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the third real number.");
            double c = double.Parse(Console.ReadLine());
            if (a > b)
            {
                if (b > c)
                {
                    Console.WriteLine("{0},{1},{2}", a, b, c);
                }
                else
                {
                    if (c > a)
                    {
                        Console.WriteLine("{0},{1},{2}", c, a, b);
                    }
                    else
                    {
                        Console.WriteLine("{0},{1},{2}", a, c, b);
                    }
                }
            }
            else
            {
                if (b>c)
                {
                    if (c>a)
                    {
                        Console.WriteLine("{0},{1},{2}",b,c,a);
                    }
                    else
                    {
                        Console.WriteLine("{0},{1},{2}",b,a,c);
                    }
                }
                else
                {
                    Console.WriteLine("{0},{1},{2}",c,b,a);
                }
            }

        }
    }
}
