using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("arr", "Array must be initialized.");
        }

        if (arr.Length == 0)
        {
            throw new ArgumentException("Array cannot be empty.", "arr");
        }

        if ((startIndex < 0) || (startIndex >= arr.Length))
        {
            throw new ArgumentOutOfRangeException("startIndex", "Start index should be within the boundaries of the array.");
        }

        if (count < 0)
        {
            throw new ArgumentException("The length of the subsequence should be positive", "count");
        }

        if (startIndex + count > arr.Length)
        {
            throw new ArgumentOutOfRangeException("count",
                "The number of elements in the subsequence does not fit the array with the specified startIndex.");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new ArgumentException("The string cannot be empty.", "str");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("count", "The length of the subsequence cannot be negative.");
        }

        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException("count",
                "The number of characters in the subsequence cannot exceed the length of the string.");
        }
        
        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        if (number <= 1)
        {
            throw new ArgumentOutOfRangeException("number", "Only non-negative numbers greater than 1 can be prime.");
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                throw new Exception("The number is not prime!");
            }
        }
    }

    public static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));

        // Throws an exception therefore commenting it.
        //// Console.WriteLine(ExtractEnding("Hi", 100));

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalculateAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
