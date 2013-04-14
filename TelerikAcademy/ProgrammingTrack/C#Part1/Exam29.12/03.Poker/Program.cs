using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Poker
{
    class Program
    {
        static void Main()
        {
            string card;
            int value,length=0,status=0,startIndex=-1,counter=0;
            int[] mass = new int[13];
            bool check=false;
            for (int i = 0; i <= 4; i++)
            {
                card = Console.ReadLine();
                if (int.TryParse(card,out value))
                    mass[value-2]+=1;
                else
                {
                    if (card=="J")
                        mass[9]+=1;
                    else if (card=="Q")
                        mass[10]+=1;
                    else if (card=="K")
                        mass[11]+=1;
                    else
                        mass[12]+=1;
                }
            }
            for (int i=0;i<=12;i++)
            {
                if (mass[i]==5)
                {
                    Console.WriteLine("Impossible");
                    check=true;
                    break;
                }
                else if (mass[i]==4)
                {
                    Console.WriteLine("Four of a Kind");
                    check=true;
                    break;
                }
                else
                {
                    if (mass[i]==3)
                    {
                        if (status==2)
                            status=5;
                        else status=3;
                    }
                    else if (mass[i]==2)
                    {
                        if (status==3)
                            status=5;
                        else if (status==2)
                            status=4;
                        else status=2;
                    }
                }
            }
            if (!check)
            {
                for (int i = 0; i < 13; i++)
                {
                    if (mass[i] > 1)
                        break;
                    if (mass[i] == 0)
                    {

                        if (length != 0)
                            break;
                    }
                    else
                    {
                        if (length == 0)
                            startIndex = i;
                        length++;
                    }
                }
            }
            counter=12;
            while ((startIndex == 0) && (counter != 0))
            {
                if (mass[counter] == 1)
                {
                    length++;
                    counter--;
                }
                else counter = 0;
            }

            if (!check)
            {
                if (length==5)
                    Console.WriteLine("Straight");
                else if (status==5)
                    Console.WriteLine("Full House");
                else if (status==3)
                    Console.WriteLine("Three of a Kind");
                else if (status==4)
                    Console.WriteLine("Two Pairs");
                else if (status==2)
                    Console.WriteLine("One Pair");
                else
                    Console.WriteLine("Nothing");
            }
            


        }
    }
}
