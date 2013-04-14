using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PrintNNumbers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter n.");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
