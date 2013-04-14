using System;
/* Write a program that reads an integer number and calculates and prints its square root.
 * If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". 
 * Use try-catch-finally. */


namespace _01.ReadingAnIntegerNumber
{
    class Program
    {
        static void Main()
        {
            int number;
            Console.WriteLine("Please enter the number.");
            try
            {
                number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new FormatException("You cannot enter negative numbers.");
                }
                else
                {
                    double squareRoot = Math.Sqrt(number);
                    Console.WriteLine("The square root of the number is {0}.", squareRoot);
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine(e. Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }

        }
    }
}
