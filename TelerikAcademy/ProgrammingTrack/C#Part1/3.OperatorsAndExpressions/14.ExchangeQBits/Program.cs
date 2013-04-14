using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.ExchangeQBits
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter a number.");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the value of p.");
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the value of k.");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the value of q.");
            int q = int.Parse(Console.ReadLine());
            int bit1,bit2;
            for (int i = 0; i < k; i++)
            {
                bit1 = (number & (1 << (p + i))) != 0 ? 1 : 0;
                bit2 = (number & (1 << (q + i))) != 0 ? 1 : 0;
                if (bit1 == 0)
                {
                    number = number & (~(1 << (q + i)));
                }
                else
                {
                    number = number | (1 << (q + i));
                }
                if (bit2 == 0)
                {
                    number = number & (~(1 << (p + i)));
                }
                else
                {
                    number = number | (1 << (p + i));
                }
            }
            Console.WriteLine(number);
                
            }
    }
}
