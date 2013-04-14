using System;
/* Extend the program to support also subtraction and multiplication of polynomials.
 */

namespace _12.PolynomialSubstractionMultiplication
{
    class Program
    {
        static void Main()
        {
            decimal[] array1 = new decimal[10] { 7, 4, 2, 12, 34, 2, 1, 35, 66, 2 };
            decimal[] array2 = new decimal[6] { 23.01m, 322, 34, 2, 0, 0.1m };
            if (array1.Length > array2.Length)
                array1 = Multiply(array1, array2);
            else
                array1 = Multiply(array2, array1);
            PrintPolynomial(array1);
        }
        // Изваждането на практика използва същия алгоритъм като събирането в предната задача.
        static decimal[] Substract(decimal[] longArray, decimal[] shortArray)
        {
            decimal[] newArray = new decimal[longArray.Length];
            int intermediate = longArray.Length - shortArray.Length;
            for (int i = 0; i < intermediate; i++)
                newArray[i] = longArray[i];
            for (int i = intermediate; i < longArray.Length; i++)
                newArray[i] = longArray[i] - shortArray[i - intermediate];
            return newArray;
        }

        static void PrintPolynomial(decimal[] array)
        {
            Console.WriteLine("The result of the operation is:");
            int m = array.Length - 1;
            bool flag = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] != 0)
                {
                    if ((!flag) && (array[i] >= 0))
                        Console.Write("{0}*x^{1}", array[i], m);
                    else if (array[i] >= 0)
                        Console.Write("+{0}*x^{1}", array[i], m);
                    else
                        Console.Write("{0}*x^{1}", array[i], m);
                    flag = true;
                    m--;
                }
            }
            if (array[array.Length - 1] > 0)
                Console.WriteLine("+{0}", array[array.Length - 1]);
            else if (array[array.Length - 1] < 0)
                Console.WriteLine(array[array.Length - 1]);
        }

        // При умножението се създава нов масив с дължина, равна на най-голямата нова степен.
        static decimal[] Multiply(decimal[] longArray, decimal[] shortArray)
        {
            decimal[] newArray = new decimal[longArray.Length + shortArray.Length - 1];
            for (int i=0;i<shortArray.Length;i++)
                for (int j = 0; j < longArray.Length; j++)
                {
                    // Индексът се получава със събиране, а стойността - с умножение.
                    newArray[i + j] = longArray[j] * shortArray[i];
                }
            return newArray;
        }
    }
}
