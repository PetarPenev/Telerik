using System;

/* Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. 
 * Use variable number of arguments. */

namespace _14.IntegerMethods
{
    class Program
    {
        static void Main()
        {
            int[] array = new int[10] { 145, 123125, 12, 3, 4, 8, -23, -1, 56, 5432 };
            double resultRealNumber=0;
            int result = 0;
            long resultLong = 0;
            result = Minimum(array);
            Console.WriteLine("The minimal number is {0}.",result);
            result = Maximum(array);
            Console.WriteLine("The maximal number is {0}.", result);
            result = Sum(array);
            Console.WriteLine("The sum is {0}.",result);
            resultRealNumber = Average(array);
            Console.WriteLine("The average is {0}.",resultRealNumber);
            resultLong = Product(array);
            Console.WriteLine("The product is {0}.",resultLong);
        }

        static int Minimum(int[] array)
        {
            int minimumNumber = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
                if (array[i] < minimumNumber)
                    minimumNumber = array[i];
            return minimumNumber;
        }

        static int Maximum(int[] array)
        {
            int maximumNumber = int.MinValue;
            for (int i = 0; i < array.Length; i++)
                if (array[i] > maximumNumber)
                    maximumNumber = array[i];
            return maximumNumber;
        }

        static int Sum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            return sum;
        }

        static double Average(int[] array)
        {
            int sum = 0;
            sum = Sum(array);
            return ((double)sum / array.Length);
        }

        static long Product(int[] array)
        {
            long product = 1;
            for (int i = 0; i < array.Length; i++)
                product *= array[i];
            return product;
        }
    }
}
