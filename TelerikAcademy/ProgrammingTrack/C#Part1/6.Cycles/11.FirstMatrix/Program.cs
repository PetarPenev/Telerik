using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.FirstMatrix
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter n between 1 and 20.");
            int n=int.Parse(Console.ReadLine());
            int[,] matrixArray = new int[n,n];
            for (int i=1;i<=n;i++)
            {
                for (int j=i;j<n+i;j++)
                {
                    matrixArray[i-1,j-i]=j;
                }
            }
            for (int i=0;i<n;i++)
            {
                for (int j=0;j<n;j++)
                {
                    Console.Write("{0,3}",matrixArray[i,j]);
                }
                Console.WriteLine();
            }



        }
    }
}
