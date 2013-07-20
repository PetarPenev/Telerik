namespace _03.CombinationsWithoutDuplicates
{
    using System;
    using System.Text;

    public class Program
    {
        private static int[] resultingSet;

        private static StringBuilder result = new StringBuilder();

        public static void Main()
        {
            Console.WriteLine("Please enter n.");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter k.");
            int k = int.Parse(Console.ReadLine());

            resultingSet = new int[k];

            GenerateCombinationsWithDuplicates(0, n, 0);
            Console.WriteLine(result.ToString().TrimEnd());
        }

        private static void GenerateCombinationsWithDuplicates(int currentIndex, int n, int lastElement)
        {
            if (currentIndex >= resultingSet.Length)
            {
                result.Append(string.Join(", ", resultingSet) + Environment.NewLine);
                return;
            }

            for (int i = lastElement + 1; i <= n; i++)
            {
                resultingSet[currentIndex] = i;
                GenerateCombinationsWithDuplicates(currentIndex + 1, n, i);
            }
        }
    }
}

