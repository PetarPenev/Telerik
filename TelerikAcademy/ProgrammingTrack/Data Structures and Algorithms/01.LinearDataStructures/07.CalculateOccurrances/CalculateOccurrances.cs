namespace _07.CalculateOccurrances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CalculateOccurrances
    {
        public static void Main()
        {
            int[] array = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            Dictionary<int, int> numberOfOccurrances = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (numberOfOccurrances.Keys.Contains(array[i]))
                {
                    numberOfOccurrances[array[i]]++;
                }
                else
                {
                    numberOfOccurrances.Add(array[i], 1);
                }
            }

            var sortedKeys = numberOfOccurrances.Keys.ToList();
            sortedKeys.Sort();

            for (int i = 0; i < sortedKeys.Count; i++)
            {
                Console.WriteLine("{0} -> {1} times", sortedKeys[i], numberOfOccurrances[sortedKeys[i]]);
            }
        }
    }
}
