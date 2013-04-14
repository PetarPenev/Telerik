using System;

/* Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. */

namespace _19.Permutations
{
    class Program
    {
        static void Main()
        {
            int n;;
            string result = "{";
            Console.WriteLine("Please enter n.");
            n = int.Parse(Console.ReadLine());
            // Правим масив, в който се съдържат числата от 0 до n. 
            int[] array = new int[n];
            for (int i=0;i<n;i++)
                array[i]=i+1;
            // Извикваме метода, който генерира пермутациите им.
            Permutations(array, 0, result,0);

        }

        static void Permutations(int[] array, int index, string result, int elements)
        {
            if (elements == array.Length - 1)
            {
                result += array[index] + "}";
                Console.WriteLine(result);
                result = result.Substring(0, result.Length - Convert.ToString(array[index]).Length - 1);
            }
            else
            {
                for (int i = index; i < array.Length; i++)
                {
                    // Ако не сме на първата итерация на цикъла, разменяме първия от оставащите елементи с всеки следващ
                    // и викаме метода с начален индекс +1.
                    if (i != index)
                    {
                        array[index] += array[i];
                        array[i] = array[index] - array[i];
                        array[index] -= array[i];
                    }
                    result += array[index] + ",";
                    Permutations(array, index + 1, result, elements + 1);
                    result = result.Substring(0, result.Length - Convert.ToString(array[index]).Length - 1);
                    // Връщаме елементите по местата им.
                    if (i != index)
                    {
                        array[index] += array[i];
                        array[i] = array[index] - array[i];
                        array[index] -= array[i];
                    }
                }
            }

        }
    }
}
