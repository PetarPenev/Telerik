using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumOfNNumbers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter n.");
            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Please enter a number.");
                double num = double.Parse(Console.ReadLine());
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
