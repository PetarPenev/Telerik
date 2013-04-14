using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FactorialNK
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter n.");
            decimal n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter k.");
            decimal k = int.Parse(Console.ReadLine());
            decimal nfac=1;
            decimal kfac=1;
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
            decimal result = nfac/kfac;
            Console.WriteLine(result);
        }
    }
}
