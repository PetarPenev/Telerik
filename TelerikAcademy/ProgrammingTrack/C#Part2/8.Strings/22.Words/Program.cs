using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/* Write a program that reads a string from the console and lists all different words
 * in the string along with information how many times each word is found. */


namespace _22.Words
{
    class Program
    {
        static void Main()
        {
            // В решението отново се използва речник, в който ключове са думите, а стойности - броят на срещанията им.
            Console.WriteLine("Please enter the string.");
            string input = Console.ReadLine();
            Dictionary<string,int> words= new Dictionary<string,int>();
            // Този път не приравнявам главни на малки букви, тоест Pop и pop се броят за различни думи - може да 
            // има разлика в изписването, която да прави такива думи различни - например Google e съществително
            // собствено име, а google е глагол, затова не ги приравнявам като еднакви думи.
            foreach (Match c in Regex.Matches(input, @"\b[\w|\d]+\b"))
            {
                if (words.ContainsKey(c.Value))
                    words[c.Value] += 1;
                else
                    words.Add(c.Value, 1);
            }
            foreach (string c in words.Keys)
                Console.WriteLine("{0} : {1}", c, words[c]);
        }
    }
}
