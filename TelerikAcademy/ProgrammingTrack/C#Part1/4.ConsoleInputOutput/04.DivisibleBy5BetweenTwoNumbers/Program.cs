using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DivisibleBy5BetweenTwoNumbers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the first integer.");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second integer.");
            int b = int.Parse(Console.ReadLine());
            int num = 0;
            for (int i = a; i <= b; i++)
            {
                if (i % 5 == 0)
                {
                    num += 1;
                }
            }
            Console.WriteLine(num);
        }
    }
}
