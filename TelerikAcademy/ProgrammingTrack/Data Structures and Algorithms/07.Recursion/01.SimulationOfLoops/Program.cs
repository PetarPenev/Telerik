namespace _01.SimulationOfLoops
{
    using System;
    using System.Text;

    public class Program
    {
        private static StringBuilder result = new StringBuilder();

        private static int[] loopArray;

        public static void Main()
        {
            Console.WriteLine("Please enter n.");
            int numberOfLoops = int.Parse(Console.ReadLine());
            loopArray = new int[numberOfLoops];
            SimulateLoops(0, numberOfLoops);
            Console.WriteLine(result.ToString().TrimEnd());
        }

        private static void SimulateLoops(int currentIndex, int numberOfLoops)
        {
            if (currentIndex >= loopArray.Length)
            {
                result.Append(string.Join(", ", loopArray) + Environment.NewLine);
                return;
            }

            for (int i = 1; i <= numberOfLoops; i++)
            {
                loopArray[currentIndex] = i;
                SimulateLoops(currentIndex + 1, numberOfLoops);
            }
        }
    }
}
