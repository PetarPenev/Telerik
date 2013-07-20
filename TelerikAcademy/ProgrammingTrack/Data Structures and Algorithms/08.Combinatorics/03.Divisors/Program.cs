namespace _03.Divisors
{
    using System;

    public class Program
    {
        private static int numberWithLeastDivisors = -1;

        private static int numberOfMinDivisors = int.MaxValue;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] values = new int[n];

            for (int i = 0; i < n; i++)
            {
                values[i] = int.Parse(Console.ReadLine());
            }

            PermuteRep(values, 0, values.Length);
            Console.WriteLine(numberWithLeastDivisors);
        }

        private static void PermuteRep(int[] arr, int start, int n)
        {
            CheckPermutation(arr);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, n);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[n - 1] = firstElement;
            }
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        private static void CheckPermutation(int[] permutationArray)
        {
            int number = 0;

            for (int i = permutationArray.Length - 1; i >= 0; i--)
            {
                number += permutationArray[i] * GetDegree(10, permutationArray.Length - 1 - i);
            }

            int numberOfDivisors = 1;
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    numberOfDivisors++;
                }
            }

            if ((numberOfDivisors < numberOfMinDivisors) || 
                ((numberOfDivisors == numberOfMinDivisors) && (number < numberWithLeastDivisors)))
            {
                numberOfMinDivisors = numberOfDivisors;
                numberWithLeastDivisors = number;
            }
        }

        private static int GetDegree(int number, int degree)
        {
            int numberToReturn = 1;
            for (int i = 0; i < degree; i++)
            {
                numberToReturn *= number;
            }

            return numberToReturn;
        }
    }
}