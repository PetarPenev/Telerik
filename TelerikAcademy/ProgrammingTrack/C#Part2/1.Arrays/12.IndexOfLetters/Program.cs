using System;

/* Write a program that creates an array containing all letters from the alphabet (A-Z). Read a word from the console and print the index of each of its letters in the array.
*/

namespace _12.IndexOfLetters
{
    class Program
    {
        static void Main()
        {
            //Декларираме масива и въвеждаме думата.
            char[] mass = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                'Q', 'R', 'S', 'T', 'U','V', 'W', 'X', 'Y', 'Z'};
            string word;
            bool found=false;
            int maxIndex=25,minIndex=0,midpoint=0,index=0;
            Console.WriteLine("Please enter the word.");
            word = Console.ReadLine();
            // Според мен условието означава да се декларират само по веднъж всички букви и затова избирам да използвам само
            // главните и конвентирам думата до главни букви. Ако искаме да направим разлика между главни и малки букви,
            // то следващият ред е излишен, а в масива трябва да добавим и малките букви. Алгоритъмът иначе не се променя.
            word=word.ToUpper();
            // Използваме двоично търсене (binary search), тъй като масивът се явява сортиран (при сравняване на отделните
            // char елементи се сравняват техните стойности в int от ASCII таблицата, а стойността на всеки следващ е 
            // по-висока от тази на предишния с единица.
            // По условие се иска да се изведе индексът на буквата в масива (държа да обърна внимание, че индексите
            // започват от 0, а не от 1.
            foreach (char c in word)
            {
                minIndex = 0;
                maxIndex = 25;
                found = false;
                while ((!found) && (minIndex <= maxIndex))
                {
                    midpoint = (minIndex + maxIndex) / 2;
                    if (mass[midpoint] == c)
                    {
                        found = true;
                        index = midpoint;
                    }
                    else if (mass[midpoint] > c)
                        maxIndex = midpoint - 1;
                    else
                        minIndex = midpoint + 1;
                }
                if (!found)
                {
                    Console.WriteLine("The string is not a word!");
                    break;
                }
                else
                    Console.WriteLine("The index of {0} is {1}.",c,index);
            }
            
        }
    }
}
