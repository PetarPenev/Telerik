using System;

/* Write a method that checks if the element at given position in given array of integers is bigger
 * than its two neighbors (when such exist). */

namespace _05.BiggerThanNeighbours
{
    class Program
    {
        static void BiggerThanNeighbours(int[] array, int index)
        {
            if ((index < 0) || (index >= array.Length))
            {
                Console.WriteLine("This element does not exist.");
                return;
            }
            int numNeighbours = 0;
            bool gotLeftNeighbour = false;
            // Проверяваме дали елементът не е първи или последен и определяме колко съседи има.
            if (index == 0)
            {
                if (array.Length != 1)
                    numNeighbours = 1;
            }
            else if (index == array.Length - 1)
            {
                if (array.Length != 1)
                {
                    numNeighbours = 1;
                    gotLeftNeighbour = true;
                }
            }
            else
            {
                numNeighbours = 2;
            }
            switch (numNeighbours)
            {
                // Ако масивът има само един елемент, то той няма съседи
                case 0:
                    Console.WriteLine("The element has no neighbours");
                    break;
                // При един съсед проверяваме дали е ляв или десен и го сравняваме е елемента
                case 1:
                    if (gotLeftNeighbour)
                    {
                        if (array[index] > array[index - 1])
                            Console.WriteLine("The element is bigger than its only existing neighbour - the one on the left.");
                        else
                            Console.WriteLine("The element is not bigger than its only neighbour - the one on the left.");
                    }
                    else
                    {
                        if (array[index] > array[index + 1])
                            Console.WriteLine("The element is bigger than its only neighbour - the one on the right.");
                        else
                            Console.WriteLine("The element is not bigger than its only neighbour - the one on the right.");
                    }
                    break;
                // При два съседа го сравняваме с тях.
                case 2:
                    if ((array[index]>array[index-1]) && (array[index]>array[index+1]))
                        Console.WriteLine("The element is bigger than its neighbours.");
                    else
                        Console.WriteLine("The element is not bigger than its neighbours.");
                    break;
                default:
                    Console.WriteLine("This is impossible.");
                    break;
            }

        }
        static void Main()
        {
            int[] array = new int[15] { 2, 76, 11, 4, 23, 11, 5, 13, 23, 33, 1, -5, 3, -12, 7 };
            int index = 0;
            bool check = false;
            // Можем да въведем само и единствено индекс, който съществува в масива. Индексите започват от 0 до array.Length-1.
            while (!check)
            {
                Console.WriteLine("Please enter the index of the element.");
                check=int.TryParse(Console.ReadLine(),out index);
            }
            BiggerThanNeighbours(array, index);

        }
    }
}
