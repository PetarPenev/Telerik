using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.OddOrEven
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter a Number.");
            int number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                if (number == 0)
                {
                    Console.WriteLine("The number is even and it is zero.");
                }
                else
                {
                    Console.WriteLine("The number is even.");
                }
            }
            else
            {
                Console.WriteLine("The number is odd.");
            }

        }
    }
}
