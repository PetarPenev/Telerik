using System;

/* Write a program that sorts an array of integers using the merge sort algorithm*/

// Използвам методи за решението на задачата, не успях да измисля начин да я реша без методи без да повтарям безумно много код.
namespace _13.MergeSort
{
    class Program
    {
        static void Main()
        {
            // Въвеждаме масив.
            int[] initialArray = new int[] { 2, 7, 5, 3, 1, -5, int.MinValue };
            // Викаме алгоритъма MergeSort.
            initialArray = MergeSort(initialArray);
            // Извеждаме резултата.
            for (int i = 0; i < initialArray.Length - 1; i++)
            {
                Console.Write("{0}, ", initialArray[i]);
            }
            Console.Write(initialArray[initialArray.Length-1]);
            Console.WriteLine();

        }
        // Рекурсивен метод за MergeSort.
        static int[] MergeSort(int[] elements)
        {
            // Ако масивът е с дължина 0 или 1, го връщаме, защото вече е сортиран.
            if ((elements.Length == 0) || (elements.Length == 1))
                return elements;
            // В противен случай го разделяме на два масива и правим MergeSort на всеки от тях.
            else
            {
                int n = elements.Length / 2;
                int[] mass1 = new int[n];
                int[] mass2 = new int[elements.Length - n];
                for (int i = 0; i < n; i++)
                    mass1[i] = elements[i];
                for (int i = n; i < elements.Length; i++)
                    mass2[i - n] = elements[i];
                mass1 = MergeSort(mass1);
                mass2 = MergeSort(mass2);
                // Връщаме слетият от двата масива масив.
                return Merge(mass1, mass2);
            }
        }
        // Метод за сливане на два масива.
        static int[] Merge(int[] elements1, int[] elements2)
        {
            int newLength=elements1.Length+elements2.Length;
            int[] newArray=new int[newLength];
            int currentIndex1=0,currentIndex2=0;
            // Вземаме най-малкия елемент от първите невзети елементи от двата масива докато не вземем всички 
            // елементи от единия масив.
            while ((currentIndex1<elements1.Length) && (currentIndex2<elements2.Length))
            {
                if (elements1[currentIndex1]<elements2[currentIndex2])
                {
                    newArray[currentIndex1+currentIndex2]=elements1[currentIndex1];
                    currentIndex1++;
                }
                else
                {
                    newArray[currentIndex1+currentIndex2]=elements2[currentIndex2];
                    currentIndex2++;
                }
            }
            // Вземаме останалите елементи от масива, който е по-голям.
            while (currentIndex1<elements1.Length)
            {
                newArray[currentIndex1+currentIndex2]=elements1[currentIndex1];
                currentIndex1++;
            }
            while (currentIndex2<elements2.Length)
            {
                newArray[currentIndex1+currentIndex2]=elements2[currentIndex2];
                currentIndex2++;
            }
            // Връщаме сортирания общ масив.
            return newArray;
        }

        
        }
    }

