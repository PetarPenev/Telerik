using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.IncreaseAge10
{
    class Program
    {
        static void Main()
        {
            string year;
            int YearBirth;
            Console.WriteLine("Enter your age.");
            year = Console.ReadLine();
             YearBirth = int.Parse(year);
             if (YearBirth <0)
             {
                 Console.WriteLine("Error: Your age is incorrectly specified");
             }
             else
             {

                 YearBirth+= 10;
                 Console.WriteLine("Your age in 10 years will be {0} years old.", YearBirth);
             }
           
        }
    }
}
