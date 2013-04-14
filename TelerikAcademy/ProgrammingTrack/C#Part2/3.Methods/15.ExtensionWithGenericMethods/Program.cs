using System;
/* Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.). 
 * Use generic method (read in Internet about generic methods in C#). */

namespace _15.ExtensionWithGenericMethods
{
    class Program
    {
        static void Main()
        {
            decimal[] array = new decimal[10] { 145, 123125, 12, 3, 4, 8, -23, -1, 56, 5432 };
            dynamic resultRealNumber = 0;
            dynamic result = 0;
            dynamic resultLong = 0;
            result = Minimum(array);
            Console.WriteLine("The minimal number is {0}.", result);
            result = Maximum(array);
            Console.WriteLine("The maximal number is {0}.", result);
            result = Sum(array);
            Console.WriteLine("The sum is {0}.", result);
            resultRealNumber = Average(array);
            Console.WriteLine("The average is {0}.", resultRealNumber);
            resultLong = Product(array);
            Console.WriteLine("The product is {0}.", resultLong);
        }

        static T Minimum<T>(T[] array)
        {
            dynamic minimumNumber = array[0];
            for (int i = 1; i < array.Length; i++)
                if (array[i] < minimumNumber)
                    minimumNumber = array[i];
            return minimumNumber;
        }

        static T Maximum<T>(T[] array)
        {
            dynamic maximumNumber = array[0];
            for (int i = 1; i < array.Length; i++)
                if (array[i] > maximumNumber)
                    maximumNumber = array[i];
            return maximumNumber;
        }

        static T Sum<T>(T[] array)
        {
            dynamic sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            return sum;
        }

        static decimal Average<T>(T[] array)
        {
            dynamic sum = 0;
            sum = Sum(array);
            return ((decimal)sum / array.Length);
        }

        static T Product<T>(T[] array)
        {
            dynamic product = 1;
            for (int i = 0; i < array.Length; i++)
                product *= array[i];
            return product;
        }
    }
}
