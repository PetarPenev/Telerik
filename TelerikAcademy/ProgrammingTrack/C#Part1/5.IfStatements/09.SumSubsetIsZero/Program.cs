using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.SumSubsetIsZero
{
    class Program
    {
        static void Main()
        {
            int[] numbers = new int[5];
            for (int i=0;i<5;i++)
            {
                Console.WriteLine("Please enter an integer number.");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            bool check=false;
            for (int i=0;i<5;i++)
            {
                if (numbers[i]==0)
                {
                    check=true;
                    Console.WriteLine("A possible subset is {0}",numbers[i]);
                }
                for (int j=i+1;j<5;j++)
                {
                    if (numbers[i]+numbers[j]==0)
                    {
                        check=true;
                        Console.WriteLine("A possible subset is {0} and {1}",numbers[i],numbers[j]);
                    }
                    for (int k=j+1;k<5;k++)
                    {
                        if (numbers[i]+numbers[j]+numbers[k]==0)
                        {
                            check=true;
                            Console.WriteLine("A possible subset is {0} and {1} and {2}", numbers[i],numbers[j],numbers[k]);
                        }
                        for (int l=k+1;l<5;l++)
                        {
                            if (numbers[i]+numbers[j]+numbers[k]+numbers[l]==0)
                            {
                                check=true;
                                Console.WriteLine("A possible subset is {0} and {1} and {2} and {3}", numbers[i], numbers[j], numbers[k], numbers[l]);
                            }
                        }
                    }
                }
            }
            if (numbers[0]+numbers[1]+numbers[2]+numbers[3]+numbers[4]==0)
            {
                check=true;
                Console.WriteLine("A possible subset is {0} and {1} and {2} and {3} and {4}",numbers[0],numbers[1],numbers[2],numbers[3],numbers[4]);
            }
            if (check==false)
            {
                Console.WriteLine("No such subsets exist");
            }
        }
    }
}
