using System;
/* Write a method that calculates the number of workdays between today and given date, passed as parameter. Consider that 
 * workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.*/

namespace _05.NumberOfWorkdays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Въвеждаме празниците в масив. Тъй като за нас годината няма значение при проверката,
            // ние ги инициализираме за 2013.
            DateTime[] array = new DateTime[10] {new DateTime(2013,1,1), new DateTime(2013,3,3), new DateTime(2013,5,1),
                new DateTime(2013,5,6), new DateTime(2013,5,24), new DateTime(2013,9,6), new DateTime(2013,9,22),
                new DateTime(2013,12,24), new DateTime(2013,12,25), new DateTime(2013,12,31)};
            Console.WriteLine("Please enter the date");
            int date = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the month.");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the year");
            int year = int.Parse(Console.ReadLine());
            DateTime dueDate = new DateTime(year, month, date);
            DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            int workDays = 0;
            if ((currentDate.DayOfWeek != DayOfWeek.Saturday) && (currentDate.DayOfWeek != DayOfWeek.Sunday) && (Array.IndexOf(array, new DateTime(2013, currentDate.Month, currentDate.Day)) == -1))
                workDays++;
            // Правим проверка дали датата е в бъдещето или миналото, като в единия случай добавяме 1 ден, а в другия - 
            // изваждаме един (в случая добавяме -1, което е еквивалентно).
            // Задачата не определя по какъв начин да се смятат крайните дни, тоест дали интервала да е отворен или затворен.
            // Приел съм, че настоящият ден, който се взема от системата, е включен в интервала, докато крайният
            // ден, въвеждащ се от клавиатурата, не се включва.
            if (dueDate < currentDate)
            {
                currentDate = currentDate.AddDays(-1);
                while ((currentDate.Month != dueDate.Month) || (currentDate.Date != dueDate.Date) || (currentDate.Year != dueDate.Year))
                {
                    /* Правим специална проверка за 29 февруари, защото ако го инициализираме по стандартния
                     * начин (Array.IndexOf(array, new DateTime(2013, currentDate.Month, currentDate.Day)) == -1)),
                     * получаваме грешка. */
                    if ((currentDate.Day == 29) && (currentDate.Month == 2))
                    {
                        if ((currentDate.DayOfWeek != DayOfWeek.Saturday) && (currentDate.DayOfWeek != DayOfWeek.Sunday))
                            workDays++;
                    }
                    // Правим проверка дали денят не е събота, неделя или празник (празниците като дати са еднакви във всяка 
                    // година, така че е ОК да ги инициализираме в масива през 2013 и да разглеждаме само дата и месец при проверка.
                    else if ((currentDate.DayOfWeek != DayOfWeek.Saturday) && (currentDate.DayOfWeek != DayOfWeek.Sunday) && (Array.IndexOf(array, new DateTime(2013, currentDate.Month, currentDate.Day)) == -1))
                        workDays++;
                    currentDate = currentDate.AddDays(-1);
                }
                Console.WriteLine("The number of workdays is {0}.", workDays);
                return;
            }
            else
            {
                currentDate = currentDate.AddDays(1);
                while ((currentDate.Month != dueDate.Month) || (currentDate.Date != dueDate.Date) || (currentDate.Year != dueDate.Year))
                {
                    /* Правим специална проверка за 29 февруари, защото ако го инициализираме по стандартния
                     * начин (Array.IndexOf(array, new DateTime(2013, currentDate.Month, currentDate.Day)) == -1)),
                     * получаваме грешка. */
                    if ((currentDate.Day == 29) && (currentDate.Month == 2))
                    {
                        if ((currentDate.DayOfWeek != DayOfWeek.Saturday) && (currentDate.DayOfWeek != DayOfWeek.Sunday))
                            workDays++;
                    }
                    // Правим проверка дали денят не е събота, неделя или празник (празниците като дати са еднакви във всяка 
                    // година, така че е ОК да ги инициализираме в масива през 2013 и да разглеждаме само дата и месец при проверка.
                    else if ((currentDate.DayOfWeek != DayOfWeek.Saturday) && (currentDate.DayOfWeek != DayOfWeek.Sunday) && (Array.IndexOf(array, new DateTime(2013, currentDate.Month, currentDate.Day)) == -1))
                        workDays++;
                    currentDate = currentDate.AddDays(1);
                }
            }
            Console.WriteLine("The number of workdays is {0}.",workDays);
        }
    }
}
