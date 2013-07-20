namespace _05.ZigZagLines
{
    using System;

    public class Program
    {
        private static int[] lineArray;
        private static bool[] usedArray;
        private static int counter = 0;

        public static void Main()
        {
            string[] arguments = Console.ReadLine().Split(' ');
            int n = int.Parse(arguments[0]);
            int k = int.Parse(arguments[1]);
            lineArray = new int[k];
            usedArray = new bool[n];
            for (int i = 0; i < n; i++)
            {
                ConstructLine(i, 0, 1);
            }

            Console.WriteLine(counter);
        }

        private static void ConstructLine(int currentElement, int position, int checkRelation)
        {
            lineArray[position] = currentElement;
            usedArray[currentElement] = true;
            position++;

            if (position >= lineArray.Length)
            {
                counter++;
                usedArray[currentElement] = false;
                return;
            }

            if (checkRelation == 1)
            {
                for (int i = currentElement - 1; i >= 0; i--)
                {
                    if (!usedArray[i])
                    {
                        ConstructLine(i, position, -checkRelation);
                    }
                }
            }
            else
            {
                for (int i = currentElement + 1; i < usedArray.Length; i++)
                {
                    if (!usedArray[i])
                    {
                        ConstructLine(i, position, -checkRelation);
                    }
                }
            }

            usedArray[currentElement] = false;
        }
    }
}