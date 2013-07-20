namespace _04.LongestSubsequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestSubsequence
    {
        public static List<int> FindLongestSubsequence(List<int> sequence)
        {
            int startMaxIndex = 0;
            int startCurrentIndex = 0;
            int maxLength = 1;
            int currentLength = 1;

            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] != sequence[i - 1])
                {
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        startMaxIndex = startCurrentIndex;
                    }

                    currentLength = 1;
                    startCurrentIndex = i;
                }
                else
                {
                    currentLength++;
                }
            }

            // We need to take care for the subsequence that includes the last element.
            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                startMaxIndex = startCurrentIndex;
            }

            var resultList = sequence.Skip(startMaxIndex).Take(maxLength);

            return resultList.ToList<int>();
        }

        public static void Main()
        {
            // The method takes priority and, in case of more than one subsequences of the same length,
            // returns the first one of them.
            List<int> sequence = new List<int>() { 3, 3, 3, 5, 5, 11, 11, 11, 2, 2, 2 };
            var result = FindLongestSubsequence(sequence);

            Console.WriteLine("The subsequence is:");
            foreach (var number in result)
            {
                Console.Write("{0} ", number);
            }
        }
    }
}
