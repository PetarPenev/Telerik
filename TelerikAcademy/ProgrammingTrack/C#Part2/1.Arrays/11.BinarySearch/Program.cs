using System;

/* Write a program that finds the index of given element in a sorted array of integers by 
 * using the binary search algorithm (find it in Wikipedia).*/


namespace _11.BinarySearch
{
    class Program
    {
        static void Main()
        {
            // Имаме променливи за максимален и минимален индекс на разглежданата част от масива (в началото
            // са 0 и massLength), булева променлива за намерен елемент и променлива за индекса му, както и такава
            // за средния елемент на разглежданата част от масива.
            int  element = 0, maxIndex, minIndex=0, midpoint=0,index=0; 
            bool check = false, found = false;
            int[] mass = new int[] {23 , 21 , 34 , 67 , 34 , 21};
            // Сортираме масива, в случай че е несортиран. Ако приемем, че винаги е сортиран, този ред е излишен и може
            // да го закоментираме.
            Array.Sort(mass);
            check=false;
            while (!check)
            {
                Console.WriteLine("Please enter the element.");
                check = int.TryParse(Console.ReadLine(), out element);
            }
            maxIndex = mass.Length-1;
            // Въртим цикъла или докато не намерим елемента, или докато не се изравнят индексите. Изчисляваме средния елемент
            // в разглежданата част от масива и, ако е равен на търсения елемент, индикираме, че сме го намерили; ако е 
            // по-голям, търсим само в лявата част на масива, ако е по-малък - в дясната.
            while ((!found)&&(minIndex<=maxIndex))
            {
                midpoint = (minIndex + maxIndex) / 2;
                if (mass[midpoint] == element)
                {
                    found = true;
                    index = midpoint;
                }
                else if (mass[midpoint] > element)
                    maxIndex = midpoint-1;
                else
                    minIndex = midpoint+1;
            }
            // Извеждаме резултата. Обърнете внимание, че се извежда индекса на елемента в масива (индексите започват от 0),
            // а не поредният му номер в последователността (тези номера започват от 1). Така например при {1,3...}, за 3
            // ще се изведе 1, а не 2.
            if (!found)
                Console.WriteLine("There is no such element in the array");
            else
                Console.WriteLine("The index of the element is {0}.",index);
        }
    }
}
