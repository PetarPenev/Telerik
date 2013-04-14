using System;
using System.Text;

/* Write a program to check if in a given expression the brackets are put correctly. */

namespace _03.CorrectBrackets
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the string.");
            // Четем израза.
            StringBuilder input = new StringBuilder(Console.ReadLine());
            int counter = 0;
            bool check = false;
            // За отваряща скоба прибавяме 1, за затваряща - вадим едно, докато циклим през стринга. В случай, че 
            // в някакъв момент броячът стане по-малък от 0, значи имаме грешка в поставянето на скобите - имаме
            // затваряща скоба, която няма своя отваряща скоба.
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                    counter++;
                if (input[i] == ')')
                    counter--;
                if (counter < 0)
                {
                    check = true;
                    break;
                }
            }
            // Ако накрая броячът не е нула, то имаме незатворени скоби и съответно - грешка.
            if (counter != 0)
                check = true;
            if (check == true)
                Console.WriteLine("Incorrect Expression.");
            else
                Console.WriteLine("Correct Expression.");
        }
    }
}