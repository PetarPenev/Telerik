using System;


namespace _14.QuickSort
{
    class Program
    {
        static void Main()
        {
            // Въвеждаме масив.
            string[] initialArray = new string[] { "Microsoft", "Apple", "HP", "Yahoo", "Oracle", "Google", "Nintendo" };
            initialArray = QuickSort(initialArray);
            // Извеждаме резултата.
            for (int i = 0; i < initialArray.Length - 1; i++)
                Console.Write("{0}, ", initialArray[i]);
            Console.Write(initialArray[initialArray.Length - 1]);
            Console.WriteLine();

        }
        // Метод за сортиране - директно приложение на алгоритъма QuickSort.
        static string[] QuickSort(string[] elements)
        {
            if ((elements.Length == 0) || elements.Length == 1)
                return elements;
            else if (elements.Length == 2)
            {
                if (elements[0].CompareTo(elements[1]) <= 0)
                    return elements;
                else
                {
                    string intermediate;
                    intermediate = elements[0];
                    elements[0] = elements[1];
                    elements[1] = intermediate;
                    return elements;
                }
            }
            else
            {
                int index = elements.Length / 2, counter = 0;
                for (int i = 0; i < elements.Length; i++)
                    if (elements[i].CompareTo(elements[index]) < 0)
                        counter++;
                string[] leftArray = new string[counter];
                string[] rightArray = new string[elements.Length - 1 - counter];
                int leftCounter = 0, rightCounter = 0;
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i].CompareTo(elements[index]) < 0)
                    {
                        leftArray[leftCounter] = elements[i];
                        leftCounter++;
                    }
                    else if (i != index)
                    {
                        rightArray[rightCounter] = elements[i];
                        rightCounter++;
                    }
                }
                leftArray = QuickSort(leftArray);
                rightArray = QuickSort(rightArray);
                return Merge(leftArray, elements[index], rightArray);
            }
        }
        // Метод, с който сливаме в един масив два други масива и средния елемент между тях (този, който е точно на мястото си.
        static string[] Merge(string[] mass1, string element, string[] mass2)
        {
            int newLength = mass1.Length + 1 + mass2.Length;
            string[] newArray = new string[newLength];
            for (int i = 0; i < mass1.Length; i++)
                newArray[i] = mass1[i];
            newArray[mass1.Length] = element;
            int startIndex = mass1.Length + 1;
            for (int i = startIndex; i < newLength; i++)
            {
                newArray[i] = mass2[i - startIndex];
            }
            return newArray;
        }
    }
}
