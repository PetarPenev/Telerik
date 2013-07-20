namespace _01.Coins
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the sum.");
            int initialSum = int.Parse(Console.ReadLine());
            int sum = initialSum;

            if (sum < 0)
            {
                Console.WriteLine("Sum must be a non - negative integer.");
            }

            int numberOfFiveCoins = 0;
            if (sum / 5 > 0)
            {
                numberOfFiveCoins += sum / 5;
                sum -= 5 * numberOfFiveCoins;
            }

            int numberOfTwoCoins = 0;
            if (sum / 2 > 0)
            {
                numberOfTwoCoins += sum / 2;
                sum -= 2 * numberOfTwoCoins;
            }

            int numberOfOneCoins = sum;

            Console.WriteLine("The sum {0} can be reached with the following coins - {1} coin(s) of 5, {2} coin(s) of 2 and {3} coin(s) of 1.",
                initialSum, numberOfFiveCoins, numberOfTwoCoins, numberOfOneCoins);
        }
    }
}