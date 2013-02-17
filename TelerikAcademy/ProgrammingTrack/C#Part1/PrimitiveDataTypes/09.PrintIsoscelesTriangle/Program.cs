using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PrintIsoscelesTriangle
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            char symbol = '\u00A9'; 
            int i, j;
            for (i = 1; i < 4; i++)
            {
                Console.WriteLine();
                for (j = 1; j <= 3 - i; j++)
                {
                    Console.Write(" ");
                }
                for (j = 4 - i; j <= 2 + i; j++)
                {
                    Console.Write(symbol);
                }
                for (j = 3 + i; j <= 5; j++)
                {
                    Console.Write(" ");
                }
            }

        }
    }
}
