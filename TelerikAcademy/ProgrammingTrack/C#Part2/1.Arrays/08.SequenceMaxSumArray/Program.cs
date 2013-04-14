using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Write a program that finds the sequence of maximal sum in given array.*/
namespace _08.SequenceMaxSumArray
{
    class Program
    {
        static void Main()
        {
            // Използвам проста имплементация на алгоритъма на Kadane, с малки изменения. 
            // Имаме текуща сума и стартов индекс на
            // текущата сума, както и максимална сума, стартов и краен индекс на максималната сума.
            int maxOverall=-1,maxIntermediate=0,startIndex=0,startIndexIntermediate=0,endIndex=0;
            bool  flag=false;
            string result;
            // Въвеждаме стойности в масива.
            int[] mass = new int[] { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
            /* Обхождаме масива 1 път. Към текущата сума добавяме първия елемент. Ако текущият елемент е по-голям от текущата 
             * сума, то можем да пренебрегнем всички предишни елементи (сборът им е отрицателен) и да започнем нова
             * текуща сума от този елемент. Ако пък текущата сума е по-голяма от максималната сума, то можем да присвоим
             * на максималната сума текущата сума, да зададем за стартовия й индекс стартовия индекс на текущата сума
             * и за краен индекс текущия индекс.*/
            for (int i=0;i<mass.Length;i++)
            {
                maxIntermediate+=mass[i];
                if (mass[i]>maxIntermediate)
                {
                    startIndexIntermediate=i;
                    maxIntermediate=mass[i];
                }
                if (maxIntermediate > maxOverall)
                {
                    maxOverall = maxIntermediate;
                    startIndex = startIndexIntermediate;
                    endIndex = i;
                    flag = true;
                }
            }
            // Извеждаме резултата. За да не се чупи решението, когато няма положителни числа, въвеждаме флагова променлива 
            // flag, която има стойност true само в случай, че maxOverall се е променило, тоест има елемент>=0.
            if (!flag)
            {
                Console.WriteLine("There are no positive elements in an array.");
            }
            else
            {
                result = "{";
                for (int i = startIndex; i <= endIndex; i++)
                    result += String.Format("{0} ",mass[i]);
                result += "}";
                Console.WriteLine(result);
            }
            

            
        }
    }
}
