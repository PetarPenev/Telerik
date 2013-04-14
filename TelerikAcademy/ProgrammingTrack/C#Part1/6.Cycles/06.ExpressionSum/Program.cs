using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ExpressionSum
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter n.");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter x.");
            int x = int.Parse(Console.ReadLine());
            decimal sum = 1;
            decimal fac=1;
            int degrees= x;
            sum+=fac/degrees;
            for (int i = 2; i <= n; i++)
            {
                fac *= i;
                degrees *= x;
                sum += fac / degrees;
            }
            Console.WriteLine(sum);
        }
    }
}
