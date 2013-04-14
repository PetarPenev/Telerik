using System;
using System.Text.RegularExpressions;

/* Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe". */

namespace _20.Palindromes
{
    class Program
    {
        static void Main()
        {
            bool checkPalindorme=true;
            string text = "ABBA is the group of pop idols at the lamal canal in Oso.";
            // Взимаме всички думи от текста с регулярен израз.
            foreach (Match c in Regex.Matches(text,@"\b[\w]+"))
            {
                checkPalindorme=true;
                // За да изведем правилно и думите, в които има главна буква, правим всички букви главни (и поп, и Поп са
                // палиндроми.
                string word = c.Value.ToUpper();
                // Проверяваме дали първият символ на думата съвпада с последния, вторият с предпоследния и т.н.
                for (int i=0; i<word.Length/2; i++)
                {
                    if (word[i]!=word[word.Length-1-i])
                        checkPalindorme=false;
                }
                    // Ако да, извеждаме на конзолата.
                if (checkPalindorme)
                    Console.WriteLine(c.Value);
                
            }
        }
    }
}
