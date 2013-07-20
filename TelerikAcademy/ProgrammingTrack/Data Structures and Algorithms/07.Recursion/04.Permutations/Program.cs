namespace _04.Permutations
{
    using System;
    using System.Text;

    public class Program
    {
        private static int[] numbersArray;
        private static bool[] checkArray;

        private static StringBuilder result = new StringBuilder();

        public static void Main()
        {
            Console.WriteLine("Please enter n.");
            int n = int.Parse(Console.ReadLine());
            numbersArray = new int[n];
            checkArray = new bool[n];

            GeneratePermutations(0);
            Console.WriteLine(result.ToString().TrimEnd());
        }

        private static void GeneratePermutations(int currentIndex)
        {
            if (currentIndex >= numbersArray.Length)
            {
                result.Append(string.Join(", ", numbersArray) + Environment.NewLine);
                return;
            }

            for (int i = 0; i < checkArray.Length; i++)
            {
                if (!checkArray[i])
                {
                    numbersArray[currentIndex] = i + 1;
                    checkArray[i] = true;
                    GeneratePermutations(currentIndex + 1);
                    checkArray[i] = false;
                }
            }
        }
    }
}
