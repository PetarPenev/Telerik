using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AnotherFactorialExpression
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter n.");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter k.");
            int k = int.Parse(Console.ReadLine());
            decimal nfac = 1;
            decimal kfac = 1;
            decimal diffac = 1;
            if (n != 0)
            {
                for (int i = 2; i <= n; i++)
                {
                    nfac *= i;
                }
            }
            if (k != 0)
            {
                for (int i = 2; i <= k; i++)
                {
                    kfac *= i;
                }
            }
            if ((k - n) != 0)
            {
                for (int i = 2; i <= (k-n); i++)
                {
                    diffac *= i;
                }
            }
            decimal result = nfac * kfac / diffac;
            Console.WriteLine(result);
        }
    }
}
