using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Exchange3Bits
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter a number.");
            int number = int.Parse(Console.ReadLine());
            int[] bits;
            bits = new int[10];
            bits[1] = (number & 1 << 3) != 0 ? 1 : 0;
            bits[2] = (number & 1 << 4) != 0 ? 1 : 0;
            bits[3] = (number & 1 << 5) != 0 ? 1 : 0;
            bits[4] = (number & 1 << 24) != 0 ? 1 : 0;
            bits[5] = (number & 1 << 25) != 0 ? 1 : 0;
            bits[6] = (number & 1 << 26) != 0 ? 1 : 0;
            for (int i=1;i<=3;i++)
            {
                if (bits[i]==0)
                {
                    number=number&(~(1<<(i+23)));
                }
                else
                {
                    number=number|(1<<(i+23));
                }
            }
            for (int i=4;i<=6;i++)
            {
                if (bits[i]==0)
                {
                    number=number&(~(1<<(i-1)));
                }
                else
                {
                    number=number|(1<<(i-1));
                }
            }
            Console.WriteLine(number);
        }
    }
}
