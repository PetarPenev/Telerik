using System;
using System.Linq;

namespace Library
{
    public static class LINQmethods
    {
        // 3 Task - students with first name before last
        public static Student[] FirstBeforeLast(Student[] arr)
        {
            var firstBeforeLast =
                from student in arr
                where student.FirstName.CompareTo(student.LastName) == -1
                select student;
            Student[] array = firstBeforeLast.ToArray();
            return array;
        }

        // 4 Task - students between 18 and 24 years old
        public static Student[] AgeInterval(Student[] arr)
        {
            var ageInterval =
                from student in arr
                where ((student.Age >= 18) && (student.Age <= 24))
                select student;
            Student[] array = ageInterval.ToArray();
            return array;
        }

        // Task 5 - the LINQ part - by first and last names in descending orders
        public static Student[] OrderByNames(Student[] arr)
        {
            var ordered =
                from student in arr
                orderby student.FirstName descending, student.LastName descending
                select student;
            Student[] array = ordered.ToArray();
            return array;
        }

        // Task 6 - the LINQ part - numbers divisible by 3 & 7
        public static int[] DivisibleNumbers(int[] arr)
        {
            var ordered =
                from number in arr
                where ((number % 3 == 0) && (number % 7 == 0)) // alternatively, we can make only one check - number%21
                select number;
            int[] array = ordered.ToArray();
            return array;
        }
    }
}
