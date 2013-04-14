using System;
/* Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below. */

namespace _11.PolynomialsAdd
{
    class Program
    {
        static void Main()
        {
            decimal[] array1 = new decimal[10] { 0, 4, 2, 12, 34, 2, 1, 35, 66, 2 };
            decimal[] array2 = new decimal[6] { 23.01m, 322, 34, 2, 0, 0.1m};
            // Вземаме като първи аргумент полинома от по висока степен.
            if (array1.Length > array2.Length)
                array1=Add(array1, array2);
            else
                array1=Add(array2, array1);
            PrintPolynomial(array1);
        }

        static decimal[] Add(decimal[] longArray, decimal[] shortArray)
        {
            decimal[] newArray = new decimal[longArray.Length];
            int intermediate = longArray.Length - shortArray.Length;
            // Коефициентите на всички елементи "в повече" просто се преписват.
            for (int i = 0; i < intermediate; i++)
                newArray[i] = longArray[i];
            // Другите се събират.
            for (int i = intermediate; i < longArray.Length; i++)
                newArray[i] = longArray[i] + shortArray[i - intermediate];
            return newArray;
        }

        static void PrintPolynomial(decimal[] array)
        {
            Console.WriteLine("The result of the addition is:");
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

    }
}
