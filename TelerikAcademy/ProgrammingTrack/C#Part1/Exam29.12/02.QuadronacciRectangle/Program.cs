using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.QuadronacciRectangle
{
    class Program
    {
        static void Main()
        {
            long n1, n2, n3, n4, intermediate;
            byte r, c;
            n1 = long.Parse(Console.ReadLine());
            n2 = long.Parse(Console.ReadLine());
            n3 = long.Parse(Console.ReadLine());
            n4 = long.Parse(Console.ReadLine());
            r = byte.Parse(Console.ReadLine());
            c = byte.Parse(Console.ReadLine());
            Console.Write("{0} {1} {2} {3}", n1, n2, n3, n4);
            if (c > 4)
                Console.Write(" ");
            for (int i = 1; i <= r; i++)
            {

                for (int j = 1; j <= c; j++)
                {
                    if ((i == 1) && (j == 1))
                    {
                        j += 4;
                        if (j > c)
                            break;
                    }
                    intermediate = n1 + n2 + n3 + n4;
                    Console.Write(intermediate);
                    if (j != c)
                        Console.Write(" ");
                    n1 = n2;
                    n2 = n3;
                    n3 = n4;
                    n4 = intermediate;
                }
                Console.WriteLine();
            }
        }
    }
}
