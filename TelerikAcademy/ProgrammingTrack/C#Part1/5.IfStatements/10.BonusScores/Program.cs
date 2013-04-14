using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.BonusScores
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter a digit.");
            int a = int.Parse(Console.ReadLine());
            int value=0;
            switch (a)
            {
                case 1:
                case 2:
                case 3:
                    value = a * 10;
                    break;
                case 4:
                case 5:
                case 6:
                    value = a * 100;
                    break;
                case 7:
                case 8:
                case 9:
                    value = a * 1000;
                    break;
                default:
                    Console.WriteLine("Error! The value is either 0 or not a digit.");
                    break;
            }
            if (value!=0)
            {
                Console.WriteLine(value);
            }
        }
    }
}
