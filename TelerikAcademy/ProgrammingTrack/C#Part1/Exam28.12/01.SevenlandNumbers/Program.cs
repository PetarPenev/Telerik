using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SevenlandNumbers
{
    class Program
    {
        static void Main()
        {
            short number;

            number = short.Parse(Console.ReadLine());
            if (number % 10 == 6)
            {
                if ((number % 100 == 66)&&(number%1000!=666))
                {
                    number += 34;
                }
                else if (number % 1000 == 666)
                {
                    number += 334;
                }
                else
                    number += 4;
            }
            else
            {
                number += 1;
            }
            Console.WriteLine(number);
        }
    }
}
