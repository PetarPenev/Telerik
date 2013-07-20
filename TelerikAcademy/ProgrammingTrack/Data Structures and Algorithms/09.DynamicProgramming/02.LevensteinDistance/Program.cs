namespace _02.LevensteinDistance
{
    using System;

    public class Program
    {
        private static readonly decimal CostOfDeletion = 0.9m;

        private static readonly decimal CostOfInsertion = 0.8m;

        private static readonly decimal CostOfRemoval = 1m;

        public static void Main()
        {
            FindDistance("developer", "enveloped");
        }

        private static void FindDistance(string firstWord, string secondWord)
        {
            int firstWordLength = firstWord.Length;
            int secondWordLength = secondWord.Length;

            string transformedFirstWord = "_" + firstWord;
            string transformedSecondWord = "_" + secondWord;

            decimal[,] valueArray = new decimal[firstWordLength + 1, secondWordLength + 1];

            for (int i = 0; i <= firstWordLength; i++)
            {
                valueArray[i, 0] = i * CostOfDeletion;
            }

            for (int j = 0; j <= secondWordLength; j++)
            {
                valueArray[0, j] = j * CostOfInsertion;
            }

            for (int i = 1; i <= firstWordLength; i++)
            {
                for (int j = 1; j <= secondWordLength; j++)
                {
                    if (transformedFirstWord[i] == transformedSecondWord[j])
                    {
                        valueArray[i, j] = valueArray[i - 1, j - 1];
                    }
                    else
                    {
                        decimal min = CostOfDeletion + valueArray[i - 1, j];
                        if (CostOfInsertion + valueArray[i, j - 1] < min)
                        {
                            min = CostOfInsertion + valueArray[i, j - 1];
                        }

                        if (CostOfRemoval + valueArray[i - 1, j - 1] < min)
                        {
                            min = CostOfRemoval + valueArray[i - 1, j - 1];
                        }

                        valueArray[i, j] = min;
                    }
                }
            }

            Console.WriteLine("The total cost of the transformation is {0}.", valueArray[firstWordLength, secondWordLength]);
        }
    }
}