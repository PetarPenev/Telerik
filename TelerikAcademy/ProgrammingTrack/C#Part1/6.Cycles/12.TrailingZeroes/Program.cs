using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.TrailingZeroes
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter n.");
            int n = int.Parse(Console.ReadLine());
            int div = 5;
            int sum = 0;
            while (n >= div)
            {
                sum += n / div;
                div*=5;
            }
            Console.WriteLine(sum);
        }
    }
}
