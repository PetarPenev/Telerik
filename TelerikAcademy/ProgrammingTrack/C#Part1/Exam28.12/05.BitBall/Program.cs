using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BitBall
{
    class Program
    {
        static void Main()
        {
            byte[,] mass = new byte[8, 8];
            byte number;
            bool checkFull = false;
            int length,result1=0,result2=0,num1=0,num2=0;
            string intNumber;
            for (int i = 0; i < 8; i++)
            {
                number = byte.Parse(Console.ReadLine());
                intNumber = Convert.ToString(number,2);
                
                length = intNumber.Length;
                foreach (char c in intNumber)
                {
                    if (c == '1')
                        mass[i, 8 - length] = 1;
                    length -= 1;
                }
            }
           /* for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    Console.Write(mass[i, j]);
                Console.WriteLine();
            }*/
            for (int i = 0; i < 8; i++)
            {
                number = byte.Parse(Console.ReadLine());
                intNumber = Convert.ToString(number,2);
                length = intNumber.Length;
                foreach (char c in intNumber)
                {
                    if (c == '1')
                    {
                        if (mass[i, 8 - length] == 1)
                            mass[i, 8 - length] = 0;
                        else
                            mass[i, 8 - length] = 2;
                    }

                    length -= 1;
                }
            }
            /*for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (mass[j, i] != 0)
                        mass[9, i] += 1;*/
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (mass[j, i] == 1)
                    {
                        num1 = 1;
                        checkFull = true;
                    }
                    if (mass[j, i] == 2)
                    {
                        if (checkFull==false)
                            num2 = 1;
                        else
                            num1 = 0;
                    }
                }
                result1 += num1;
                result2 += num2;
                num1 = 0;
                num2 = 0;
                checkFull = false;
            }
            Console.WriteLine("{0}:{1}",result1,result2);
            /*for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    Console.Write(mass[i, j]);
                Console.WriteLine();
            }*/

            }
        }
    }

