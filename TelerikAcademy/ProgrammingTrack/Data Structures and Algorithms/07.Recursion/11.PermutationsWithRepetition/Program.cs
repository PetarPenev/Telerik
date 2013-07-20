namespace _11.PermutationsWithRepetition
{
    using System;
    using System.Text;

    public class Program
    {
        private static int[] permutationSet = new int[] { 1, 7, 5, 5 };

        private static StringBuilder result = new StringBuilder();

        public static void Main()
        {
            Array.Sort(permutationSet);
            GetPermutations(0);
            Console.WriteLine("The permutations of {{{0}}} are the following:", string.Join(", ", permutationSet));
            Console.WriteLine(result.ToString().TrimEnd());
        }

        private static void GetPermutations(int elementIndex)
        {
            result.Append(string.Join(", ", permutationSet) + Environment.NewLine);

            int intermediateValue = 0;
            if (elementIndex < permutationSet.Length)
            {
                for (int i = permutationSet.Length - 2; i >= elementIndex; i--)
                {
                    for (int j = i + 1; j < permutationSet.Length; j++)
                    {
                        if (permutationSet[i] != permutationSet[j])
                        {
                            intermediateValue = permutationSet[i];
                            permutationSet[i] = permutationSet[j];
                            permutationSet[j] = intermediateValue;
                            GetPermutations(i + 1);
                        }
                    }

                    intermediateValue = permutationSet[i];
                    for (int k = i; k < permutationSet.Length - 1; k++)
                    {
                        permutationSet[k] = permutationSet[k + 1];
                    }

                    permutationSet[permutationSet.Length - 1] = intermediateValue;
                }              
            }
        }
    }
}