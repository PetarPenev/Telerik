using System;

namespace _09.SecondSolutionFloatRepresentation
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter a floating point number.");
            float number = float.Parse(Console.ReadLine());
            // Използваме метода GetBytes като получаваме масив от 4 числа от тип int, които вземаме
            // в обратен ред и представяме в двоична бройна система, като допълваме отляво с нули до 8 символа.
            byte[] array = BitConverter.GetBytes(number);
            Console.WriteLine("The number is:");
            for (int i = array.Length - 1; i >= 0; i--)
                Console.Write(Convert.ToString(array[i],2).PadLeft(8,'0'));
            Console.WriteLine();
        }
    }
}
