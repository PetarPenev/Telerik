using System;


/* Write a program that finds the maximal sequence of equal elements in an array.
*/
namespace _04.MaxmumSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            // В maxLength съхраняваме най-дългата последователност от елементи, в intLength - текущата последователност
            // от елементи, а в element - елементът, който е в най-дългата последователност от елементи.
            int maxLength = 0, intLength=0,element;
            bool check = false;
            string result;
            // Няма изискване за въвеждане на масива от конзолата, затова го hardcode-ваме. Приел съм, че 
            // масивът е от тип int, промяна на типа на елементите
            // няма да окаже съществено влияние върху алгоритъма за решаване на задачата.
            int[] mass = new int[] { 3, 6, 6, 3, 4, 4, 4, 11, 4, 4, 4, 4, 12, 12, 12, 12 };
            intLength=1;
            element=mass[0];
            // Обхождаме масива, като отчитаме дължината на текущата последователност от елементи, а при прекъсването й 
            // я сравняваме с максималната, променяме максималната, ако текущата е по-голяма от нея, и задаваме стойност на
            // текущата дължина от единица (защото различният елемент е първи в нова серия от елементи).
            for (int i = 1; i < mass.Length; i++)
            {
                if (mass[i] == mass[i - 1])
                    intLength += 1;
                else
                {
                    if (intLength > maxLength)
                    {
                        maxLength = intLength;
                        element = mass[i - 1];
                    }
                    intLength = 1;
                }
            }
            // Правим още една проверка за последната последователност от елементи, която преди прекъсването на цикъла
            // не е сравнявана с максималната последователност.
            if (intLength > maxLength)
            {
                maxLength = intLength;
                element = mass[mass.Length - 1];
            }
            // Конструираме стринга за резултат, който се състои от къдрави скоби, между които има maxLength на брой
            // повторения на елемента в максималната последователност. Както се вижда, извежда се първата срещната максимална
            // последователност, тъй като в условието на задачата няма поставено изискване при дублиране на дължините
            // от различни елементи да се извежда тази с по-голям елемент например.
            result = "{";
            for (int i = 0; i < maxLength; i++)
                result += String.Format("{0} ", mass[i]);
            result += "}";
            Console.WriteLine("The max sequence is {0}", result);
        }
    }
}
