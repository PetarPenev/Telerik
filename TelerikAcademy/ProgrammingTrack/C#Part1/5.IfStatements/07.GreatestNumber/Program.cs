using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.GreatestNumber
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the first number.");
            double firstNum = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second number.");
            double secondNum = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the third number.");
            double thirdNum = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the forth number.");
            double forthNum = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the fifth number.");
            double fifthNum = double.Parse(Console.ReadLine());
            double max = firstNum;
            if (max < secondNum)
            {
                max = secondNum;
            }
            if (max < thirdNum)
            {
                max = thirdNum;
            }
            if (max < forthNum)
            {
                max = forthNum;
            }
            if (max < fifthNum)
            {
                max = fifthNum;
            }
            Console.WriteLine("The greatest number is {0}", max);

        }
    }
}
