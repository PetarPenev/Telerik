using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IsItDivisibleBy5and7
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please Enter a Number.");
            int number = int.Parse(Console.ReadLine());
            if ((number%5==0) && (number%7==0))
            {
                Console.WriteLine("Yes, the number is divisible by both 5 and 7.");
            }
            else
            {
                if (number%5==0)
                {
                    Console.WriteLine("No, the number is divisible only by 5.");
                }
                else
                {
                    if (number%7==0)
                    {
                        Console.WriteLine("No, the number is divisible only by 7.");
                    }
                    else
                    {
                        Console.WriteLine("No, the number is divisible neither by 5 nor by 7");
                    }
                }
            }
        }
    }
}
