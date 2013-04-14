using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ExcelColumns
{
    class Program
    {
        static void Main()
        {
            int n,intermediate;
            ulong result=0;
            n = int.Parse(Console.ReadLine());
            char[] mass = new char[n];
            for (int i = 0; i < n; i++)
                mass[i] = char.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                result += (ulong)(mass[i] - 'A'+1) * (ulong)Math.Pow(26, (double)(n - i - 1));
            }
            
            Console.WriteLine(result);
        }
    }
}
