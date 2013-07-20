namespace _01.DoubleValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DoubleValues
    {
        public static void Main()
        {
            double[] array = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            Dictionary<double, int> numberOfOccurances = new Dictionary<double, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (numberOfOccurances.ContainsKey(array[i]))
                {
                    numberOfOccurances[array[i]]++;
                }
                else
                {
                    numberOfOccurances[array[i]] = 1;
                }
            }

            // We are doing this so that we will both follow the condition of the task about the data structure 
            // - Dictionary<TKey, TValue>, and will output the result sorted by value of keys in the dictionary.
            var ordered = numberOfOccurances.Keys.ToList();
            ordered.Sort();

            foreach (var number in ordered)
            {
                Console.WriteLine("{0} - > {1} time(s)", number, numberOfOccurances[number]);
            }
        }
    }
}
