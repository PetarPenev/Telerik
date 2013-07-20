namespace _04.LineOfColorfulBalls
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            string sequence = Console.ReadLine();
            Dictionary<char, int> balls = new Dictionary<char, int>();
            for (int i = 0; i < sequence.Length; i++)
            {
                if (balls.ContainsKey(sequence[i]))
                {
                    balls[sequence[i]]++;
                }
                else
                {
                    balls.Add(sequence[i], 1);
                }
            }

            int largestFactorialInTheDivisor = -1;
            foreach (var key in balls.Keys)
            {
                if (balls[key] > largestFactorialInTheDivisor)
                {
                    largestFactorialInTheDivisor = balls[key];
                }
            }

            BigInteger numberToDivide = Factorial(sequence.Length, largestFactorialInTheDivisor);
            BigInteger divisor = 1;
            bool alreadySkipped = false;
            foreach (var key in balls.Keys)
            {
                if (alreadySkipped || (balls[key] != largestFactorialInTheDivisor))
                {
                    divisor *= Factorial(balls[key], 1);
                }
                else
                {
                    alreadySkipped = true;
                }
            }

            Console.WriteLine(numberToDivide / divisor);
        }

        private static BigInteger Factorial(int number, int stop)
        {
            BigInteger factorialValue = 1;

            for (int i = number; i > stop; i--)
            {
                factorialValue *= i;
            }

            return factorialValue;
        }
    }
}