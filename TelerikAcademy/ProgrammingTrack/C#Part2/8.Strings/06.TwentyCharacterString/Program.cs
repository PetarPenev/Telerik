using System;

/* Write a program that reads from the console a string of maximum 20 characters. 
 * If the length of the string is less than 20, the rest of the characters should be filled with '*'. 
 * Print the result string into the console. */


namespace _06.TwentyCharacterString
{
    class Program
    {
        static void Main()
        {
            // Четем стинга.
            Console.WriteLine("Please enter the string.");
            string input = Console.ReadLine();
            // Ако е с дължина над 20, то го тримваме до 20 символа и го извеждаме.
            if (input.Length > 20)
            {
                Console.WriteLine("The string was longer than 20 characters and was trimmed to:");
                Console.WriteLine(input.Substring(0, 20));
            }
                // В противен случай го допълваме до 20 символа (ако е необходимо, тоест ако не е с дължина 20) със *.
            else
            {
                Console.WriteLine("{0}{1}",input,new string('*',20-input.Length));
            }
        }
    }
}
