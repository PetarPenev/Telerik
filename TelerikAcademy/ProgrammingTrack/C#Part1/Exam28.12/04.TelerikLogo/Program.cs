using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TelerikLogo
{
    class Program
    {
        static void Main()
        {
            int x,z,length,height,intVar1,intVar2;
            x = int.Parse(Console.ReadLine());
            z = (x + 1) / 2;
            length = 2 * z + 2 * x - 3;
            height=length;
            string[] mass = new string[height];
            intVar2=2*x-3;
            mass[0] = new string('.', (length - 2 - (2 * x - 3)) / 2) + "*" + new string('.', intVar2) + "*" + new string('.', (length - 2 - (2 * x - 3)) / 2);
            intVar1=1;
            for (int i = 1; i <= z - 1; i++)
            {
                intVar2 -= 2;
                mass[i] = new string('.', z - 1 - i) + "*" + new string('.', intVar1) + "*" + new string('.', intVar2) + "*" + new string('.', intVar1) + "*" + new string('.', z - 1 - i);
                intVar1 += 2;
            }
            intVar2 -= 2;
            intVar1=(length-2-intVar2)/2;
            for (int i = 1; i <= x - z - 1; i++)
            {
                
                mass[z + i-1] = new string('.', intVar1) + "*" + new string('.', intVar2) + "*" + new string('.', intVar1);
                intVar1+=1;
                intVar2 -= 2;
            }
            
            mass[x - 1] = new string('.', intVar1) + "*" + new string('.', intVar1);
            intVar1 -= 1;
            intVar2 = 1;
            for (int i=1;i<=x-1;i++)
            {
                mass[x+i-1]=new string('.',intVar1)+"*"+new string('.',intVar2)+"*"+new string('.',intVar1);
                intVar1-=1;
                intVar2+=2;
            }
            intVar1 += 1;
            intVar2 -= 2;
            for (int i = 1; i <= x - 2; i++)
            {
                intVar1 += 1;
                intVar2 -= 2;
                mass[2 * x + i - 2] = new string('.', intVar1) + "*" + new string('.', intVar2) + "*" + new string('.', intVar1);
            }
            mass[length - 1] = new string('.', (length - 1) / 2) + "*" + new string('.', (length - 1) / 2);
            for (int i=0;i<height;i++)
                Console.WriteLine(mass[i]);

        }
    }
}
