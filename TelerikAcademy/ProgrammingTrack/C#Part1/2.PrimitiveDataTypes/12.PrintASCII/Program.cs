using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.PrintASCII
{
    class Program
    {
        static void Main()
        {
            int i;
            char symbol;
            for (i = 0; i < 128; i++)
            {
                Console.WriteLine((char)i);
            }
        }
    }
}
