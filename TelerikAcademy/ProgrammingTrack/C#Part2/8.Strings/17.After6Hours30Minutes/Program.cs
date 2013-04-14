using System;
using System.Globalization;

/* Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
 * and prints the date and time after 6 hours and 30 minutes (in the same format) 
 * along with the day of week in Bulgarian. */

namespace _17.After6Hours30Minutes
{
    class Program
    {
        static void Main()
        {
            // Аналогично на предишната задача, с различно сплитване на входа и форматиране.
            Console.WriteLine("Please enter the date in the required format.");
            string input = Console.ReadLine();
            string[] arr = input.Split('.', ' ', ':');
            int[] array = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                array[i] = int.Parse(arr[i]);
            DateTime date = new DateTime(array[2], array[1], array[0], array[3], array[4], array[5]);
            date = date.AddHours(6.5);
            Console.WriteLine("{0} {1}", date, date.ToString("dddd", new CultureInfo("bg-BG")) );
        }
    }
}
