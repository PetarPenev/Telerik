using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinAndMaxNumber
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter n.");
            int n = int.Parse(Console.ReadLine());
            if (n < 1)
            {
                Console.WriteLine("Not a valid number of integers.");
                return;
            }
            int min, max, num;
            Console.WriteLine("Please enter a number.");
            min = max = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i++)
            {
                Console.WriteLine("Please enter a number.");
                num = int.Parse(Console.ReadLine());
                if (num < min)
                {
                    min = num;
                }
                else if (num > max)
                {
                    max = num;
                }
                
            }
            Console.WriteLine("{0},{1}", min, max);
        }
    }
}
