namespace _01.BinaryPasswords
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            long counterOfPossibilities = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    counterOfPossibilities *= 2;
                }
            }

            Console.WriteLine(counterOfPossibilities);
        }
    }
}