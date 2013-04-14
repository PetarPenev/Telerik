using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Write a program that compares two char arrays lexicographically (letter by letter).

 Цитат за лексикографска подредба от учебника на Наков:
При лексикографската наредба символите се сравняват един по един
като се започва от най-левия. При несъвпадащи символи по-рано е
масивът, чийто текущ символ е по-рано в азбуката. При съвпадение
се продължава със следващия символ вдясно. Ако се стигне до края
на единия масив, по-краткият е лексикографски по-рано. Ако всички
съответни символи от двата масива съвпаднат, то масивите са
еднакви и никой о тях не е по-рано в лексикографската наредба.*/
namespace _03.LexicographicallyCompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result=false;
            // Тъй като няма изискване масивите да бъдат въведени от конзолата, ги hardcode-ваме с цел по-лесна проверка.
            char[] mass1 = new char[] { 'f', 't', 'y', 'a', 'u' };
            char[] mass2 = new char[] { 'f', 't', 'z', 'e', 'a' };
            // Обхождаме масивите до дължината на по-малкия от тях, като ако стигнем до неравни елементи
            // извеждаме резултата за лексикографската подредба на масивите.
            for (int i = 0; i < Math.Min(mass1.Length,mass2.Length); i++)
            {
                if (mass1[i] > mass2[i])
                {
                    Console.WriteLine("The second array lexicographically precedes the first array.");
                    result = true;
                    break;
                }
                else if (mass1[i] < mass2[i])
                {
                    Console.WriteLine("The first array lexicographically precedes the second.");
                    result = true;
                    break;
                }
            }
            // Виждаме дали булевата променлива, показваща дали сме върнали резултат, е променена. Ако не е (тоест дотук
            // елементите на масивите са равни) правим проверка кой е по-къс и извеждаме лексикографската подредба според това.
            if (result == false)
            {
                if (mass1.Length < mass2.Length)
                    Console.WriteLine("The first array lexicographically precedes the second.");
                else if (mass1.Length > mass2.Length)
                    Console.WriteLine("The second array lexicographically precedes the first.");
                else
                    Console.WriteLine("The two arrays are lexicographically equal.");
            }
        }
    }
}
