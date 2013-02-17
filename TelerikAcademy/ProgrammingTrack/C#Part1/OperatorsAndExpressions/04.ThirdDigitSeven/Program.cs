using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ThirdDigitSeven
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter a number.");
            int number = int.Parse(Console.ReadLine());
            int remainder;
            remainder = number % 100;
            number = number - remainder;
            number = number % 1000;
            if (number == 700)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
