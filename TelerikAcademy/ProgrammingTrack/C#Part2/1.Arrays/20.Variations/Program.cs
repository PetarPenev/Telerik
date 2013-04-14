using System;

namespace _20.Variations
{
    class Program
    {
        static void Main()
        {
            int n, k;
            Console.WriteLine("Please enter n.");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter k.");
            k = int.Parse(Console.ReadLine());
            int[] array = new int[k];
            // Викаме метода, генериращ вариациите.
            Variations(array, n, 0);
        }

        static void Variations(int[] array, int n, int index)
        {
            // Ако сме генерирали нужния брой позиции, принтираме резултата.
            if (index == array.Length)
            {
                Console.Write("{");
                for (int i = 0; i < array.Length - 1; i++)
                {
                    Console.Write("{0},", array[i]);
                }
                Console.Write(array[array.Length - 1]);
                Console.WriteLine("}");
            }
            // В противен случай на съответния елемент на масива последователно присвояваме всички възможни стойности от 
            // 1 до n и извикваме рекурсивно метода за следващия елемент от масива.
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    array[index] = i;
                    Variations(array, n, index + 1);
                }
            }
        }
    }
}
