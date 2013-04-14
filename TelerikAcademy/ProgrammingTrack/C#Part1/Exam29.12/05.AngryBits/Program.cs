using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AngryBits
{
    class Program
    {
        static void Main()
        {
            byte[,] mass = new byte[8,16];
            ushort number;
            int initialX=0,initialY=0,result=0,currentX,currentY,lengthFlight=0,counter,length;
            string intString;
            bool checkBird=false,checkDestroyed=false,checkRotate=false,checkWin=true;
            for (int i = 0; i < 8; i++)
            {
                number = ushort.Parse(Console.ReadLine());
                intString = Convert.ToString(number, 2);
                length=intString.Length;
                foreach (char c in intString)
                {
                    if (c == '1')
                        mass[i, 16 - length] = 1;
                    length--;
                }
            }
            /*for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 16; j++)
                    Console.Write(mass[i, j]+" ");
                Console.WriteLine();
            }*/
            for (int i = 7; i >=0; i--)
            {
                for (int j = 0; j <8; j++)
                {
                    if (mass[j, i] == 1)
                    {
                        initialX = i;
                        initialY = j;
                        checkBird = true;
                        break;
                    }
                }
                if (checkBird)
                {
                    lengthFlight = 0;
                    currentX = initialX;
                    currentY = initialY;
                    while (!checkDestroyed)
                    {
                        if (!checkRotate)
                        {
                            if (currentY - 1 < 0)
                            {
                                checkRotate = true;
                                currentX++;
                                currentY++;
                                lengthFlight++;
                            }
                            else
                            {
                                currentX++;
                                currentY--;
                                lengthFlight++;
                            }
                        }
                        else
                        {
                            if (currentY + 1 > 7)
                                break;
                            if (currentX + 1 > 15)
                                break;
                            else
                            {
                                currentX++;
                                currentY++;
                                lengthFlight++;
                            }
                        }
                        if (currentX > 7)
                        {
                            if (mass[currentY, currentX] == 1)
                            {
                                checkDestroyed = true;
                                counter = 0;
                                for (int l = Math.Max(8,Math.Max(currentX - 1, 0)); l <= Math.Min(currentX + 1, 15); l++)
                                    for (int m = Math.Max(0, currentY - 1); m <= Math.Min(currentY + 1, 7); m++)
                                        if (mass[m,l] == 1)
                                        {
                                            counter++;
                                            mass[m,l] = 0;
                                        }
                                mass[initialY, initialX] = 0;
                                result += lengthFlight * counter;
                                /*for (int z = 0; z < 8; z++)
                                {
                                    for (int k = 0; k < 16; k++)
                                        Console.Write(mass[z, k] + " ");
                                    Console.WriteLine();
                                }*/
                            }
                        }

                    }
                }
                    

                checkBird = false;
                checkRotate=false;
                checkDestroyed = false;
            }
            for (int i = 0; i < 8; i++)
                for (int j = 8; j < 16; j++)
                    if (mass[i, j] == 1)
                        checkWin = false;
             if (checkWin)
                Console.WriteLine(result+" Yes");
             else
                 Console.WriteLine(result+" No");

                
        }
    }
}
