using System;

/* Write a program that finds the most frequent number in an array. */
namespace _09.MostFrequentElement
{
    class Program
    {
        static void Main()
        {
            // Задачата се решава най-лесно с речник, но реших да я решавам с масив, за да използвам само текущи знания.
            int intermediateLength=0,length,element=0;
            int[] mass = new int[] { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            // Сортираме масива.
            Array.Sort(mass);
            // Задаваме като стойност на максималната последователност такава с дължина 1 и от първия елемент.
            length=1;
            element=mass[0];
            intermediateLength=1;
            // Обхождаме масива, като проверяваме каква е текущата последователност като дължина и я сравняваме с най-дългата
            // досега, като правим промени, когато текущата стане по-дълга.
            for (int i=1;i<mass.Length;i++)
            {
                if (mass[i]==mass[i-1])
                    intermediateLength+=1;
                else
                {
                    if (intermediateLength>length)
                    {
                        length=intermediateLength;
                        element=mass[i-1];
                        intermediateLength=1;
                    }
                    intermediateLength=1;
                }
            }
            // Правим проверка за последната последователност, която не е сравнявана с максималната.
             if (intermediateLength>length)
                    {
                        length=intermediateLength;
                        element=mass[mass.Length-1];
                        intermediateLength=1;
                    }
            // Извеждаме резултат.
            Console.WriteLine("{0} ({1} times)",element,length);
        }
    }
}
