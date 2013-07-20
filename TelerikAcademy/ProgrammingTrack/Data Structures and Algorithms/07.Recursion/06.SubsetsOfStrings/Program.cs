namespace _06.SubsetsOfStrings
{
    using System;
    using System.Text;

    public class Program
    {
        private static string[] set = new string[] { "test", "rock", "fun" };

        private static string[] subset;

        private static StringBuilder result = new StringBuilder();

        public static void Main()
        {
            Console.WriteLine("Please enter k.");
            int k = int.Parse(Console.ReadLine());
            if (k > set.Length)
            {
                Console.WriteLine("k must not exceed the number of elements in the subset.");
                return;
            }

            subset = new string[k];
            GenerateSets(0, 0, k);
            Console.WriteLine(result.ToString().TrimEnd());
        }

        private static void GenerateSets(int currentIndex, int currentElementIndex, int elementsLeft)
        {
            if (currentIndex >= subset.Length)
            {
                result.Append(string.Join(", ", subset) + Environment.NewLine);
                return;
            }

            for (int i = currentElementIndex; i <= set.Length - elementsLeft; i++)
            {
                subset[currentIndex] = set[i];
                GenerateSets(currentIndex + 1, currentElementIndex + i - currentElementIndex + 1, elementsLeft - 1);
            }
        }
    }
}
