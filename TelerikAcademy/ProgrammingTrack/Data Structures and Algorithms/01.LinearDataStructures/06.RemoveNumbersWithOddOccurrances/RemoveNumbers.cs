namespace _06.RemoveNumbersWithOddOccurrances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveNumbers
    {
        public static void Main()
        {
            List<int> sequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            Dictionary<int, int> numberOfOccurances = new Dictionary<int, int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (numberOfOccurances.Keys.Contains(sequence[i]))
                {
                    numberOfOccurances[sequence[i]]++;
                }
                else
                {
                    numberOfOccurances.Add(sequence[i], 1);
                }
            }

            sequence.RemoveAll(x => numberOfOccurances[x] % 2 == 1);
            Console.WriteLine("The new sequence is:");
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
