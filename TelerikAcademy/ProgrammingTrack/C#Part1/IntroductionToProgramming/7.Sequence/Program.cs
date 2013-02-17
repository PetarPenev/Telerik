using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Sequence
{
    class Program
    {
        static void Main()
        {
            for (int i = 2; i <= 11; i++)
            {
                if (i%2== 0)
                {
                    Console.Write("{0,2}, ", i);
                }
                else if (i != 11)
                {
                    Console.Write("{0,2}, ", -i);
                }
                else
                {
                    Console.Write("{0,2}", -i);
                }
            }
        }
    }
}