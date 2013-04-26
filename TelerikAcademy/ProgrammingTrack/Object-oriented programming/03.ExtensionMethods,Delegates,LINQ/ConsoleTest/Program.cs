using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace ConsoleTest
{
    class Program
    {
        static void Main()
        {
            // Test StringBuilder
            try
            {
                StringBuilder str = new StringBuilder("Telerik Academy Students");
                Console.WriteLine(str.Substring(2));
                Console.WriteLine(str.Substring(2, 4));
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Test IEnumerable extensions
            int[] arr = new int[4] { 4, -23, 11, 3 };
            Console.WriteLine("The min value is {0}", arr.MaxValue<int>());
            Console.WriteLine("The max value is {0}", arr.MinValue<int>());
            Console.WriteLine("The sum is {0}", arr.Sum<int>());
            Console.WriteLine("The product is {0}", arr.Product<int>());
            Console.WriteLine("The average is {0}", arr.Average<int>());
            Console.WriteLine();

            // Test LINQ and Lambda functions
            // 3 task test
            Student[] std = new Student[5]{
                new Student("Acho","Georgieva",22),
                new Student("Acho","Georgiev",22),
                new Student("Galen", "Asenov",16),
                new Student("Anton", "Antonov", 40),
                new Student("Milko","Manchev",34)
            };
            Student[] studentArr = LINQmethods.FirstBeforeLast(std);
            Console.WriteLine("FirstBeforeLast:");
            foreach (var c in studentArr)
                Console.WriteLine(c);
            Console.WriteLine();

            // 4 task test
            studentArr = LINQmethods.AgeInterval(std);
            Console.WriteLine("Age Between 18 and 24:");
            foreach (var c in studentArr)
                Console.WriteLine(c);
            Console.WriteLine();

            // 5 task test - first the lambda function
            var ordered = std.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);
            Console.WriteLine("Ordered by name descending - lambda function:");
            foreach (var c in ordered)
                Console.WriteLine(c);

            Console.WriteLine();
            // Then with LINQ
            studentArr = LINQmethods.OrderByNames(std);
            Console.WriteLine("Ordered by name descending - LINQ:");
            foreach (var c in studentArr)
                Console.WriteLine(c);
            Console.WriteLine();

            int[] array = new int[7] { 2, 3, 5, 7, 21, 42, 43 };
            // 6 task - testing first with lambda expressions
            var divNumbers = Array.FindAll(array, divNumber => ((divNumber % 3 == 0) && (divNumber % 7 == 0))); // or one check - divNumber%21
            Console.WriteLine("Divisible integers - first with lambda expressions.");
            foreach (int c in divNumbers)
                Console.WriteLine(c);

            Console.WriteLine();
            Console.WriteLine("Divisible integers - now with LINQ.");
            int[] intArray = LINQmethods.DivisibleNumbers(array);
            foreach (var c in intArray)
                Console.WriteLine(c);
            Console.WriteLine();

            // Task 7 - create a timer delegate that can call a function in a specified interval.
            // You have to use the constructor for the class - it takes the function and the 
            // interval in seconds - the interval must be non-negative.
            Console.WriteLine("Call a function using only a delegate:");
            TimerWithDelegate del = new TimerWithDelegate(FunctionToTest, 1);

            // Executing the function a specific number of times by calling the Execute Timer method with 
            // a parameter the number of executions
            del.ExecuteTimer(5);
            Console.WriteLine();

            // 8 Task - using events. First we create an instance of our timer class containing the timer interval
            // and the number of function executions.
            Console.WriteLine("Call a function with an event:");
            TimerWithEvent eventTime = new TimerWithEvent(1, 5);

            // Then we create an instance of the subscriber by specifying the function to be executed and the timer to
            // subscribe to.
            SubscriberToTimerWithEvent sub = new SubscriberToTimerWithEvent(FunctionToTest, eventTime);

            // Start execution.
            eventTime.StartExecution();
            eventTime.StartExecution();
            
        }

        static void FunctionToTest()
        {
            Console.WriteLine("I got called");
        }
    }
}
