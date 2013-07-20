namespace UsingVariablesHomework
{
    using System;
    using System.Collections.Generic;

    // Created a class that wrapps the different methods. Since PrintStatistics was a multifunctional method,
    // thus not having a single purpose, I have split it in four methods (one calling the other three
    // and printing the results) each having its own purpose.
    public static class StatisticalMethods
    {
        public static double MaximumValue(double[] inputData)
        {
            if (inputData.Length == 0)
            {
                throw new ArgumentException("The array contains no value.");
            }

            double maxValue = double.MinValue;
            for (int i = 0; i < inputData.Length; i++)
            {
                if (inputData[i] > maxValue)
                {
                    maxValue = inputData[i];
                }
            }

            return maxValue;
        }

        public static double MinimumValue(double[] inputData)
        {
            if (inputData.Length == 0)
            {
                throw new ArgumentException("The array contains no value.");
            }

            double minValue = double.MaxValue;
            for (int i = 0; i < inputData.Length; i++)
            {
                if (inputData[i] < minValue)
                {
                    minValue = inputData[i];
                }
            }

            return minValue;
        }

        public static double AverageValue(double[] inputData)
        {
            double sum = 0;
            for (int i = 0; i < inputData.Length; i++)
            {
                sum += inputData[i];
            }

            double averageValue = sum / inputData.Length;
            return averageValue;
        }

        public static void PrintStatistics(double[] inputData)
        {
            var maxValue = MaximumValue(inputData);
            Console.WriteLine("The maximum value of the array is {0}.", maxValue);

            var minValue = MinimumValue(inputData);
            Console.WriteLine("The minimum value of the array is {0}.", minValue);

            var averageValue = AverageValue(inputData);
            Console.WriteLine("The average value of the array is {0}.", averageValue);
        }
    }
}
