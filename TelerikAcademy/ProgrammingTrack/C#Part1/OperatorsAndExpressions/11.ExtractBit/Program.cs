using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ExtractBit
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter an integer number.");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the bit number.");
            int b = int.Parse(Console.ReadLine());
            bool check = ((i >> b) & 1) == 1;
            if (check == true)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
