using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompareSevenDigits
{
    class Program
    {
        static void Main()
        {
            decimal number1, number2;
            Boolean compare;
            Console.WriteLine("Enter the first number.");
            number1 = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number.");
            number2 = decimal.Parse(Console.ReadLine());
            compare = Math.Abs(number1 - number2) < 0.000001m;
            Console.WriteLine(compare);
        }

    }
}
