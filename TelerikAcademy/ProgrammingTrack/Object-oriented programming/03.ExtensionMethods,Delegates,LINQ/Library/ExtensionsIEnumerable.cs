using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    // 2 task - implementing extension methods for IEnumerable
    public static class ExtensionsIEnumerable
    {
        public static decimal Sum<T>(this IEnumerable<T> arr)
        {
            if (arr.Count()==0)
                throw new ArgumentException("Cannot sum an empty collection.");
            decimal sum=0;
            try
            {
                foreach (var c in arr)
                {
                    sum += Convert.ToDecimal(c);
                }
            }
            catch (OverflowException)
            {
                throw new OverflowException("The sum exceeds the capacity of type decimal.");
            }
            return sum;
        }

        public static decimal Product<T>(this IEnumerable<T> arr)
        {
            if (arr.Count() == 0)
                throw new ArgumentException("Cannot multiply an empty collection");
            decimal product = 1;
            foreach (var c in arr)
            {
                product *= Convert.ToDecimal(c);
                if (product == 0)
                    break;
            }
            return product;
        }

        public static T MinValue<T>(this IEnumerable<T> arr) where T:IComparable
        {
            if (arr.Count() == 0)
                throw new ArgumentException("Cannot find the minimal element in an empty collection.");
            T min = arr.First();
            foreach (var c in arr)
            {
                if (c.CompareTo(min)<0)
                    min = c;
            }
            return min;
        }

        public static T MaxValue<T>(this IEnumerable<T> arr) where T:IComparable
        {
            if (arr.Count() == 0)
                throw new ArgumentException("Cannot find the maximal element in an empty collection.");
            T max = arr.First();
            foreach (var c in arr)
            {
                if (c.CompareTo(max)>0)
                    max = c;
            }
            return max;
        }

        public static decimal Average<T>(this IEnumerable<T> arr)
        {
            if (arr.Count() == 0)
                throw new ArgumentException("Cannot find average of an empty collection.");
            decimal average = 0;
            int counter = 0;
            foreach (var c in arr)
            {
                average += Convert.ToDecimal(c);
                counter++;
            }
            return average / counter;
        }
    }
}
