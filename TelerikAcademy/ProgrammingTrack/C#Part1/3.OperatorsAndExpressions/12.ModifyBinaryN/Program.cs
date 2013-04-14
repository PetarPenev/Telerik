using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ModifyBinaryN
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter an integer number.");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the value of the bit.");
            int v = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the position.");
            int p = int.Parse(Console.ReadLine());
            if (v == 0)
            {
                n = n & (~(1 << p));
            }
            else
            {
                if (v == 1)
                {
                    n = n | (1 << p);
                }
                else
                {
                    Console.WriteLine("Invalid value of v");
                    return;
                }
            }
            Console.WriteLine(n);
        }
    }
}
