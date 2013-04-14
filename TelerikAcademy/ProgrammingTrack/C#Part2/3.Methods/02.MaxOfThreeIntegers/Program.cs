using System;

/* Write a method GetMax() with two parameters that returns the bigger of two integers. 
 * Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().*/


namespace _02.MaxOfThreeIntegers
{
    class Program
    {
        static int GetMax(int firstInt, int secondInt)
        {
            return Math.Max(firstInt, secondInt);
        }
        static void Main()
        {
            int firstNumber=0, secondNumber=0, thirdNumber=0;
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Please enter the first number.");
                check = int.TryParse(Console.ReadLine(), out firstNumber);
            }
            check = false;
            while (!check)
            {
                Console.WriteLine("Please enter the second number.");
                check = int.TryParse(Console.ReadLine(), out secondNumber);
            }
            check = false;
            while (!check)
            {
                Console.WriteLine("Please enter the third number.");
                check = int.TryParse(Console.ReadLine(), out thirdNumber);
            }
            firstNumber = GetMax(firstNumber, secondNumber);
            firstNumber = GetMax(firstNumber, thirdNumber);
            Console.WriteLine("The biggest number is {0}.",firstNumber);
        }
    }
}
