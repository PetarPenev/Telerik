using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ThirdBit
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter a number.");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine((number >> 2 & 1) == 1);
        }
    }
}
