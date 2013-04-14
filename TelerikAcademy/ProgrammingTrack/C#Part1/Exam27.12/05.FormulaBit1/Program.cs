using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FormulaBit1
{
    class Program
    {
        static void Main()
        {
            
            byte[,] mass = new byte[8, 8];
            byte number;
            bool checkFinish = true;
            int length, lengthTrack = 0, turns = 0, initialX = 7, initialY = 0, direction = 1; ;
            //South 1 west 2 north 3 west 4
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
            if (mass[initialY,initialX]==1)
                checkFinish=false;
            while (checkFinish)
            {
                lengthTrack++;
                if ((initialX == 0) && (initialY == 7))
                    break;
                if (direction == 1)
                {
                    if ((initialY + 1 <= 7) && (mass[initialY + 1, initialX] == 0))
                        initialY += 1;
                    else if ((initialX - 1 >= 0) && (mass[initialY, initialX - 1] == 0))
                    {
                        turns++;
                        initialX--;
                        direction = 2;
                    }
                    else
                        checkFinish = false;
                }
                else if (direction == 2)
                {
                    if ((initialX - 1 >= 0) && (mass[initialY, initialX - 1] == 0))
                        initialX--;
                    else if ((initialY - 1 >= 0) && (mass[initialY - 1, initialX] == 0))
                    {
                        turns++;
                        initialY--;
                        direction = 3;
                    }
                    else
                        checkFinish = false;
                }
                else if (direction == 3)
                {
                    if ((initialY - 1 >= 0) && (mass[initialY - 1, initialX] == 0))
                        initialY--;
                    else if ((initialX - 1 >= 0) && (mass[initialY, initialX - 1] == 0))
                    {
                        turns++;
                        initialX--;
                        direction = 4;
                    }
                    else
                        checkFinish = false;
                }
                else
                {
                    if ((initialX - 1 >= 0) && (mass[initialY, initialX - 1] == 0))
                        initialX--;
                    else if ((initialY + 1 <= 7) && (mass[initialY + 1, initialX] == 0))
                    {
                        turns++;
                        initialY++;
                        direction = 1;
                    }
                    else
                        checkFinish = false;
                }
            }
                if (checkFinish)
                    Console.WriteLine("{0} {1}",lengthTrack,turns);
                else
                    Console.WriteLine("No {0}",lengthTrack);
                   




        }
    }
}
