using System;
using System.Linq;

/* You are given an array of strings. Write a method that sorts the array by the length of its elements 
 * (the number of characters composing them). */



namespace _08.StringOverrideComparison
{
    class Program
    {
        static void Main()
        {
            string[] array = new string[6] { "ba", "goga", "logdads", "mazaseaera", "q", "edadaawawf" };
            // Използваме Linq, за да сортираме масива, подреждайки елементите по дължина.
            Array.Sort(array, (firstString, secondString) => firstString.Length.CompareTo(secondString.Length));
            foreach (var c in array)
                Console.WriteLine(c);
        }
    }
}
