using System;
using System.Text.RegularExpressions;

/* Write a program that extracts from a given text all sentences containing given word. */

namespace _08.SentancesContainingAWord
{
    class Program
    {
        static void Main()
        {
            string sentances = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string word="in";
            // Записваме разделените изречения в стринг масив.
            string[] array = sentances.Split('.');
            // За всяко изречение проверяваме с регулярен израз дали съдържа търсената дума и, ако да, го изписваме,
            // като добавяме точка накрая (точките не са записани в стринг масива, но в оригиналния текст следват
            // след всеки елемент, записан в масива.
            foreach (string c in array)
            {
                if (Regex.IsMatch(c, "\\b" + word + "\\b"))
                    Console.WriteLine(c.Trim(' ')+".");
            }

        }
    }
}
