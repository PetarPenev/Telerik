namespace _02.StringsOddElementsCountExtraction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringExtraction
    {
        public static void Main()
        {
            string[] array = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            SortedDictionary<string, int> numberOfOccurances = new SortedDictionary<string, int>();

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

            List<string> extractedStrings = new List<string>();

            foreach (var key in numberOfOccurances.Keys)
            {
                if (numberOfOccurances[key] % 2 == 1)
                {
                    extractedStrings.Add(key);
                }
            }

            foreach (var extractedString in extractedStrings)
            {
                Console.WriteLine(extractedString);
            }
        }
    }
}
