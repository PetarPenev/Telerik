namespace _01.Salaries
{
    using System;

    public class Program
    {
        private static byte[,] matrixOfConnections;

        private static long[] calculatedSalaries;

        public static void Main()
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());
            calculatedSalaries = new long[numberOfEmployees];
            matrixOfConnections = new byte[numberOfEmployees, numberOfEmployees];
            for (int i = 0; i < numberOfEmployees; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'Y')
                    {
                        matrixOfConnections[i, j] = 1;
                    }
                }
            }

            long sumOfSalaries = 0;
            for (int i = 0; i < numberOfEmployees; i++)
            {
                sumOfSalaries += CalculateSalary(i);
            }

            Console.WriteLine(sumOfSalaries);
        }

        private static long CalculateSalary(int employeeNumber)
        {
            if (calculatedSalaries[employeeNumber] != 0)
            {
                return calculatedSalaries[employeeNumber];
            }

            bool hasEmployee = false;
            for (int i = 0; i < matrixOfConnections.GetLength(1); i++)
            {
                if (matrixOfConnections[employeeNumber, i] == 1)
                {
                    calculatedSalaries[employeeNumber] += CalculateSalary(i);
                    hasEmployee = true;
                }
            }

            if (!hasEmployee)
            {
                calculatedSalaries[employeeNumber] = 1;
            }

            return calculatedSalaries[employeeNumber];
        }
    }
}