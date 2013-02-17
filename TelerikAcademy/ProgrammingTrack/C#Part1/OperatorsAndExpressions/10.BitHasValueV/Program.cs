using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.BitHasValueV
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the number.");
            int v = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the position.");
            int p = int.Parse(Console.ReadLine());
            bool check = ((v >> p) & 1) == 1;
            if (check == true)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
