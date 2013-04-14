using System;

/* Write a program that reverses the words in given sentence. */
namespace _13.ReverseWords
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine("Please enter the sentence.");
            string sentance = "c++ , is not";
            // Сплитваме думите(+пунктуацията, която се явява прикрепена към тях) в стринг масив.
            string[] array = sentance.Split(' ');
            string intermediateString="";
            bool firstContainMark=false;
            char firstChar=' ';
            bool secondContainMark=false;
            char secondChar=' ';
            // Създаваме си масив с всички пунктуационни символи, които не трябва да се местят, а да останат по местата си.
            char[] arrayPunctuation = new char[] { '!', '.', '?', ',', ':', ';' };
            for (int i=0; i<array.Length/2;i++)
            {
                // Циклим до средата на масива, защото дотогава ще сме извършили всички размени.
                intermediateString=array[i];
                // Ако на първия елемент последният символ е пунктуация, то го запазваме и го махаме от първия стринг.
                if (Array.IndexOf(arrayPunctuation, intermediateString[intermediateString.Length-1])!=-1)
                {
                    firstContainMark=true;
                    firstChar = intermediateString[intermediateString.Length - 1];
                    intermediateString=intermediateString.Substring(0,intermediateString.Length-1);
                }
                // Същото се отнася и за елемента, с когото ще осъществяваме размяна.
                if (Array.IndexOf(arrayPunctuation, array[array.Length - i - 1][array[array.Length - i - 1].Length - 1]) != -1)
                {
                    secondContainMark=true;
                    secondChar=array[array.Length-i-1][array[array.Length-i-1].Length-1];
                    array[array.Length-i-1]=array[array.Length-i-1].Substring(0,array[array.Length-i-1].Length-1);
                }
                // Осъществяваме размяната, като долепяме нужната пунктуация, ако е необходимо.
                if (firstContainMark)
                {
                    array[i] = array[array.Length-i-1] + firstChar;
                }
                else
                {
                    array[i] = array[array.Length-i-1];
                }
                if (secondContainMark)
                {
                    array[array.Length-i-1] = intermediateString + secondChar;
                }
                else
                {
                    array[array.Length-i-1] = intermediateString;
                }
                firstContainMark = false;
                secondContainMark = false;
            }
            // Извеждаме резултата + интервалите.
            foreach (string c in array)
                Console.Write("{0} ", c);
            Console.WriteLine();
            
        }
    }
}
