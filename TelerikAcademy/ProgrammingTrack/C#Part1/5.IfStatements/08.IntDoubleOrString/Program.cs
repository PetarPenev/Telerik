using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.IntDoubleOrString
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter 1 for integer, 2 for double and 3 for string.");
            byte check = byte.Parse(Console.ReadLine());

            switch (check)
            {
                case 1:
                    Console.WriteLine("Please enter the integer.");
                    int a = int.Parse(Console.ReadLine());
                    a += 1;
                    Console.WriteLine(a);
                    break;
                case 2:
                    Console.WriteLine("Please enter the double number.");
                    double b = double.Parse(Console.ReadLine());
                    b += 1;
                    Console.WriteLine(b);
                    break;
                case 3:
                    Console.WriteLine("Please enter the string.");
                    string c = Console.ReadLine();
                    c = c + "*";
                    Console.WriteLine(c);
                    break;
                default:
                    Console.WriteLine("Incorrect specification of the type of variable.");
                    break;
            }
        }
    }
}
