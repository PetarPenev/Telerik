using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.CatalanNumbers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter n.");
            int n = int.Parse(Console.ReadLine());
            decimal upperfac=1;
            decimal lowerfac=1;
            for (int i = 2; i <= n; i++)
            {
                lowerfac *= i;
            }
            for (int i = n + 2; i <= 2 * n; i++)
            {
                upperfac *= i;
            }
            decimal result = upperfac / lowerfac;
            Console.WriteLine(result);
        }
    }
}
