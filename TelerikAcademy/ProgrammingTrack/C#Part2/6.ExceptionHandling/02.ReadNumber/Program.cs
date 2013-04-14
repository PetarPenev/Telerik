using System;

/* Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end].
 * If an invalid number or non-number text is entered, the method should throw an exception. 
 * Using this method write a program that enters 10 numbers. */


namespace _02.ReadNumber
{
    class Program
    {
        static void Main()
        {
            string result="";
            int previous=1;
            bool finished = false;
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    previous = ReadNumber(previous, 100);
                    result += previous + ",";
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
                if (i == 10)
                    finished = true;
            }
            if (finished)
                Console.WriteLine("The sequence is {0}.", result.Substring(0,result.Length-1));


        }

        static int ReadNumber(int start, int end)
        {
            Console.WriteLine("Please enter the next number.");
            try
            {
                int number = int.Parse(Console.ReadLine());
                if ((start < number) && (number < end))
                    return number;
                else
                    throw new FormatException("The number is outside the interval");
            }
            catch (FormatException)
            {
                throw;
            }
        }
    }

}
