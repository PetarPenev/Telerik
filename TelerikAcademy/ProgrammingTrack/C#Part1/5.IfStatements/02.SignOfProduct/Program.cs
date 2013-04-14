using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SignOfProduct
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the first real number");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second real number");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the third real number");
            double c = double.Parse(Console.ReadLine());
            bool zerocheck=false;
            int plussigns=0;
            if ((a==0) || (b==0) || (c==0))
            {
                zerocheck=true;
            }
            if (a>0)
            {
                plussigns+=1;
            }
            if (b>0)
            {
                plussigns+=1;
            }
            if (c>0)
            {
                plussigns+=1;
            }
            if (zerocheck==true)
            {
                Console.WriteLine(0);
            }
            else
            {
                if ((plussigns==1) || (plussigns==3))
                {
                    Console.WriteLine("+");
                }
                else
                {
                    Console.WriteLine("-");
                }
            }

        }
    }
}
