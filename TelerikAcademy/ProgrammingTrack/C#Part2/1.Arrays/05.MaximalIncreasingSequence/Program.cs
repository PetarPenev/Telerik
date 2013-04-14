using System;

/* Write a program that finds the maximal increasing sequence in an array. 
 Приел съм, че говорим за строго растяща последователност (тоест, при два равни последователни елемента, се прекъсва.
 Ако приемем, че не се прекъсва, то промяната е въпрос на смяна на > с >= в проверката.
 */
namespace _05.MaximalIncreasingSequence
{
    class Program
    {
        static void Main()
        {
            // startIndex е индексът на началото на най-дългата нарастваща последователност, length е дължината на 
            // най-дългата такава последователност, а intLength е дължината на текущата такава последователност. Инициализираме
            // стартовия индекс като 0, а дължината като 1, защото първият елемент представлява нарастваща последователност
            // с дължина 1.
            int  startIndex=0, length=1, intLength=1;
            string result;
            int[] mass = new int[] { 3, 2, 3, 4, 2, 2, 4 };
            //Обхождаме масива, като проверяваме дали текущият елемент е по-голям от предхождащия го. Можем да го направим,
            //защото започваме от втория елемент (с индекс 1) на масива и можем да го сравним с първия. В случай, че 
            //последователността се прекъсне, сравняваме я с максималната и евентуално променяме съответните стойности.
            for (int i = 1; i < mass.Length; i++)
            {
                if (mass[i] > mass[i - 1])
                    intLength += 1;
                else if (intLength > length)
                {
                    length = intLength;
                    startIndex = i - intLength;
                    intLength = 1;
                }
                else
                    intLength = 1;
            }
            //Правим проверка за последната ненамаляваща последователност, която не е сравнявана с максималната.
            if (intLength > length)
            {
                length = intLength;
                startIndex = mass.Length - intLength;
                intLength = 1;
            }
            //Образуваме стринга на резултата, представляващ {}, между които има length на брой елементи, съставляващи
            //максималната растяща последователност.
            result = "{";
            for (int i = startIndex; i < startIndex + length; i++)
                result += String.Format("{0} ", mass[i]);
            result += "}";
            Console.WriteLine(result);
        }
    }
}
