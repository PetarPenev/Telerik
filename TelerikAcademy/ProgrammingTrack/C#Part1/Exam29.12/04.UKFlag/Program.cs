using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.UKFlag
{
    class Program
    {
        static void Main()
        {
            int n,index;
            n = int.Parse(Console.ReadLine());
            index = n / 2;
            string[] mass=new string[n];
            for (int i = 0; i < index; i++)
                mass[i] = new string('.', i) + @"\" + new string('.', index - i - 1) + "|" + new string('.', index - i - 1) + @"/" + new string('.', i);
            mass[n - index - 1] = new string('-', index) + "*" + new string('-', index);
            for (int i = n - index; i < n; i++)
                mass[i] = new string('.', n - i-1) + @"/" + new string('.', i - index - 1) + "|" + new string('.', i - index - 1) + @"\" + new string('.', n - i-1);
            
            for (int i=0;i<n;i++)
                Console.WriteLine(mass[i]);
            
        }
    }
}
