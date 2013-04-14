using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Sheets
{
    class Program
    {
        static void Main()
        {
            int n,k,max;
            int[,] mass = new int[11, 2];
            for (int i = 0; i < 11; i++)
                mass[i,0] = (int)Math.Pow(2, i);
            n = int.Parse(Console.ReadLine());
            max=10;
            while (n != 0)
            {
                k = -1;
                for (int i = 0; i <= max; i++)
                {
                    if (n >= mass[i, 0])
                        k = i;
                    else
                        break;
                }
                mass[k, 1] = 1;
                n -= mass[k, 0];
            }
            for (int i = 0; i < 11; i++)
            {
                if (mass[i, 1] == 0)
                    Console.WriteLine("A" + (10 - i));
            }
        }
    }
}
