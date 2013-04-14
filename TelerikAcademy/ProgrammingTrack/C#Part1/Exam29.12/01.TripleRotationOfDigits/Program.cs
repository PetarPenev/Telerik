using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.TripleRotationOfDigits
{
    class Program
    {
        static void Main()
        {
            string k,result="";
            int length;
            k = Console.ReadLine();
            length = k.Length;
            if (length==1)
                result=k;
            else if (length == 2)
            {
                if (k[1] == '0')
                    result = k.Substring(0, 1);
                else
                    result = Convert.ToString(k[1]) + Convert.ToString(k[0]);
            }
            else if (length == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (k[k.Length-1] == '0')
                        k = k.Substring(0, k.Length - 1);
                    else
                        k = k.Substring(k.Length - 1, 1) + k.Substring(0, k.Length - 1);
                }
                result = k;
            }
            else
            {
                result = k.Substring(0, length - 3);
                for (int i = 1; i < 4; i++)
                    if (k.Substring(length - i, 1) != "0")
                        result = k.Substring(length - i, 1) + result;
            }
            
            
            Console.WriteLine(result);
        }
    }
}
