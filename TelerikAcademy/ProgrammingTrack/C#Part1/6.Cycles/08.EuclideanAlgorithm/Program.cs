using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.EuclideanAlgorithm
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the first number.");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second number.");
            int k = int.Parse(Console.ReadLine());
            while (n != k)
            {
                if (n > k)
                {
                    n = n - k;
                }
                else
                {
                    k = k - n;
                }
            }
            Console.WriteLine(n);
        }
    }
}
