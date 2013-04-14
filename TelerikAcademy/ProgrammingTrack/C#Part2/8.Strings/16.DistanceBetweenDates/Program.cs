using System;

/* Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.  */

// !!! Примерът в условието на презентацията е сгрешен, и на двете места годината трябва да е 2006, за да се получи 
// разлика от 4 дни.

namespace _16.DistanceBetweenDates
{
    class Program
    {
        static void Main()
        {
            // Четем датите, парсваме ги до DateTime със създаден за целта метод и използваме метода substract,
            // за да ги извадим.
            Console.Write("Enter the first date:");
            string firstInput = Console.ReadLine();
            Console.Write("Enter the second date:");
            string secondInput = Console.ReadLine();
            DateTime firstDate = ParseDate(firstInput);
            DateTime secondDate = ParseDate(secondInput);
            TimeSpan span = secondDate.Subtract(firstDate);
            Console.WriteLine("Distance: {0} days", span.Days);

        }

        static DateTime ParseDate(string input)
        {
            string[] array = input.Split('.');
            int[] arr = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                arr[i] = int.Parse(array[i]);
            // Подаваме аргументите в ред: година, месец, дата.
            DateTime date = new DateTime(arr[2],arr[1],arr[0]);
            return date;
        }
    }
}
