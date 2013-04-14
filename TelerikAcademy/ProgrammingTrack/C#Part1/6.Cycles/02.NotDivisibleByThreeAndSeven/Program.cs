using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.NotDivisibleByThreeAndSeven
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter n.");
            int n = int.Parse(Console.ReadLine());
            for (int i=1;i<=n;i++)
            {
                if ((i%3==0) && (i%7==0))
                {
                    continue;
                }
                else
                {
                    Console.Write("{0} ",i);
                }
            }
        }
    }
}
