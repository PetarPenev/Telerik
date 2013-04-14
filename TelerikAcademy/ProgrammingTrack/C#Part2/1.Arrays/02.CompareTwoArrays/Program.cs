using System;


/*Write a program that reads two arrays from the console and compares them element by element.*/

namespace _02.CompareTwoArrays
{
    class Program
    {
        static void Main()
        {
            int lengthMass1=0, lengthMass2=0;
            bool check=false;
            // Вкарваме проверка с check - boolean променлива, която ще използвам за проверка на коректността на данните
            
            while (!check)
            {
                Console.WriteLine("Please enter the length of the first array.");
                check=int.TryParse(Console.ReadLine(),out lengthMass1);
            }
            check=false;
            int[] mass1= new int[lengthMass1];
            // Въвеждаме елементи на първи масив.
            for (int i=0;i<lengthMass1;i++)
            {
                while (!check)
                {
                    Console.WriteLine("Please enter the {0} element.",i+1);
                    check=int.TryParse(Console.ReadLine(),out mass1[i]);
                }
                check = false;
            }
            // Въвеждаме брой елементи на втори масив.
            while (!check)
            {
                Console.WriteLine("Please enter the length of the second array.");
                check=int.TryParse(Console.ReadLine(),out lengthMass2);
            }
            check=false;
            int[] mass2= new int[lengthMass2];
            // Въвеждаме елементи на втори масив.
            for (int i=0;i<lengthMass2;i++)
            {
                while (!check)
                {
                    Console.WriteLine("Please enter the {0} element.",i+1);
                    check=int.TryParse(Console.ReadLine(),out mass2[i]);
                }
                check = false;
            }
            // Обхождаме до дължината на по-малкия масив и сравняваме всеки два елемента
            for (int i = 0; i < Math.Min(mass1.Length, mass2.Length); i++)
            {
                if (mass1[i] == mass2[i])
                    Console.WriteLine("The {0} elements are equal.", i + 1);
                else if (mass1[i] > mass2[i])
                    Console.WriteLine("The {0} element of the first array is bigger than the {0} element of the second array", i + 1);
                else
                    Console.WriteLine("The {0} element of the first array is smaller than the {0} element of the second array", i + 1);
            }
            // Извеждаме излишните елементи от масива, който е по-голям.
            if (mass1.Length>mass2.Length)
            {
                Console.Write("The first array has {0} extra elements:",mass1.Length-mass2.Length);
                for (int i=mass2.Length;i<mass1.Length-1;i++)
                    Console.Write("{0}, ",mass1[i]);
                Console.Write(mass1[mass1.Length-1]);
            }
            else if (mass2.Length>mass1.Length)
            {
                Console.Write("The second array has {0} extra element:",mass2.Length-mass1.Length);
                for (int i=mass1.Length;i<mass2.Length-1;i++)
                    Console.Write("{0}, ",mass2[i]);
                Console.Write(mass2[mass2.Length-1]);
            }
            Console.WriteLine();
        }
    }
}
