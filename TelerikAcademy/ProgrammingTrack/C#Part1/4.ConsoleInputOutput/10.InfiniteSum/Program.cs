using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.InfiniteSum
{
    class Program
    {
        static void Main()
        {
            double sum, sum1 = 1;
            int i=2;
            double temp = 0;
            do
            {
                if (i%2 == 0)
                {
                    sum=sum1;
                    temp = 1.00 / i;
                    sum1=sum1+temp;
                }
                else
                {
                    sum=sum1;
                    temp = (-1.00 / i);
                    sum1=sum1+temp;
                }
                i++;
            }
            while (Math.Abs(sum1-sum)>=0.001);
            Console.WriteLine("{0}",sum);
                    

        }
    }
}
