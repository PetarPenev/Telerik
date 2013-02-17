using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.IsPrime
{
    class Program
    {
        static void Main()
        {
            int i;
            Console.WriteLine("Please enter a number");
            int number = int.Parse(Console.ReadLine());
            bool result=true;
            for (i = 2; i < number / 2 + 1; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                    break;
                }
            }
            if (result == true)
            {
                Console.WriteLine("Yes, the number is prime");
            }
            else
            {
                Console.WriteLine("No, the number is not prime");
            }
        }
    }
}
