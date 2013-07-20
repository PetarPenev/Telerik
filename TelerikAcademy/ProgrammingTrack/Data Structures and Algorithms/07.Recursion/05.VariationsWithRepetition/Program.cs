namespace _05.VariationsWithRepetition
{
    using System;
    using System.Text;

    public class Program
    {
        private static string[] set = new string[] { "hi", "a", "b" };

        private static string[] generatedSet;

        private static StringBuilder result = new StringBuilder();

        public static void Main()
        {
            Console.WriteLine("Please enter k.");
            int k = int.Parse(Console.ReadLine());
            generatedSet = new string[k];

            GenerateVariations(0);
            Console.WriteLine(result.ToString().TrimEnd());
        }

        private static void GenerateVariations(int currentPosition)
        {
            if (currentPosition >= generatedSet.Length)
            {
                result.Append(string.Join(", ", generatedSet) + Environment.NewLine);
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                generatedSet[currentPosition] = set[i];
                GenerateVariations(currentPosition + 1);
            }
        }
    }
}