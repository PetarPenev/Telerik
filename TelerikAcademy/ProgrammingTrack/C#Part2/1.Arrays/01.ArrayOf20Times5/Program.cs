using System;


/*Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. 
 Print the obtained array on the console.*/


namespace _01.ArrayOf20Times5
{
    class Program
    {
        static void Main()
        {
            int[] mass = new int[20];
            for (int i = 0; i < 20; i++)
                mass[i] = i * 5;
            for (int i = 0; i < 19; i++)
                Console.Write("{0} ", mass[i]);
            Console.Write(mass[19]);
            Console.WriteLine();
            // Извеждаме го по този начин, за да не остава интервал след последния елемент.
        }
    }
}
