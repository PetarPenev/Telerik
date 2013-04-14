using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

/* Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
 * Display them in the standard date format for Canada. */

// Решение с регулярен израз. Несъществуващите дати (например 29.02.2005 година) не се извеждат на конзолата.

namespace _19.ExtractDates
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date;
            string text = "On the 11.12.2012 it was not like on the 11.12, nor like 08.07.2023 or 29.02.2004.";
            foreach (Match c in Regex.Matches(text,@"\b\d\d\.\d\d\.\d\d\d\d")) 
                if (DateTime.TryParseExact(c.Value, "dd.MM.yyyy",CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-Ca").DateTimeFormat.ShortDatePattern));

        }
    }
}
