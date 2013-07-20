namespace _08.FindMajorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindMajorant
    {
        public static void Main()
        {
            List<int> sequence = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            Dictionary<int, int> numberOfOccurrances = new Dictionary<int, int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (numberOfOccurrances.Keys.Contains(sequence[i]))
                {
                    numberOfOccurrances[sequence[i]]++;
                }
                else
                {
                    numberOfOccurrances.Add(sequence[i], 1);
                }   
            }

            bool majorantFound = false;
            foreach (var number in numberOfOccurrances.Keys)
            {
                if (numberOfOccurrances[number] >= (sequence.Count / 2) + 1)
                {
                    Console.WriteLine("The majorant is {0}.", number);
                    majorantFound = true;
                    break;
                }
            }

            if (!majorantFound)
            {
                Console.WriteLine("No majorant exists.");
            }
        }
    }
}
