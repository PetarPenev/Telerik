using System;

/* Write a method that adds two positive integer numbers represented as arrays of digits 
 * (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
 * Each of the numbers that will be added could have up to 10 000 digits. */


namespace _08.AddArrayOfDigits
{
    class Program
    {
        static void Main()
        {
            int[] array1 = new int[10] { 4, 6, 4, 2, 7, 1, 9, 4, 1, 6 };
            int[] array2 = new int[10] {  5,6, 2, 9, 9, 6, 3, 2, 5, 7 };
            // Подаваме като първи аргумент на метода по-дългия масив.
            if (array1.Length >= array2.Length)
                AddArraysOfDigits(array1, array2);
            else
                AddArraysOfDigits(array2, array1);

        }
        static void AddArraysOfDigits(int[] longArray, int[] shortArray)
        {
            int[] newArray = new int[longArray.Length];
            int memory=0;
            int differenceLength = longArray.Length-shortArray.Length;
            // Събираме цифрите, като в memory пазим прехвърлянето, ако има такова.
            for (int i=newArray.Length-1; i>=differenceLength;i--)
            {
                newArray[i]=longArray[i]+shortArray[i-differenceLength]+memory;
                memory=0;
                // Ако получим число >10 (тоест не е цифра), вадим от него 10 и увеличаваме memory с 1.
                if (newArray[i]>=10)
                {
                    newArray[i]-=10;
                    memory=1;
                }
            }
            // Добавяме цифрите на по-дългия масив.
            for (int i=differenceLength-1;i>=0;i--)
            {
                newArray[i]=longArray[i]+memory;
                memory=0;
            }
            // Ако все още имаме прехвърляне, си правим нов масив с една позиция повече, на която има 1.
            if (memory==1)
            {
                int[] newerArray= new int[newArray.Length+1];
                newerArray[0]=1;
                for (int i=1;i<newArray.Length+1;i++)
                    newerArray[i]=newArray[i-1];
                PrintArray(newerArray);
            }
            // Принтираме резултата.
            else
                PrintArray(newArray);
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                Console.Write("{0},", array[i]);
            Console.Write(array[array.Length-1]);
            Console.WriteLine();
        }

        
    }
}
