using System;
using System.Collections.Generic;

namespace _09.BreadthFirstSearch
{
    class Program
    {
        static void Main()
        {
            string[,] array = new string[,] {
                {"1","3","2","2","2","4"},
                {"3","3","3","2","4","4"},
                {"4","3","1","2","3","3"},
                {"4","3","1","3","3","1"},
                {"4","3","3","3","1","1"}
            };
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            int maxSequence = int.MinValue, currentSequence = 0;
            // За всяка възможна позиция викаме FindSequence. Ако резултатът е по-голям от максималната последователност,
            // то го запаметяваме.
            for (int i=0;i<array.GetLength(0);i++)
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    currentSequence = FindSequence(i, j, queue, array);
                    if (currentSequence > maxSequence)
                        maxSequence = currentSequence;
                }
            Console.WriteLine(maxSequence);
        }

        static int FindSequence(int i, int j, Queue<Tuple<int,int>> queue, string[,] array)
        {
            // Ако вече сме посетили позицията, значи сме пресметнали последователността от еднакви съседни елементи за нея
            // и можем да върнем произволно число, което е по-малко или равно на maxSequence, защото няма да се отрази на
            // крайния резултат.
            if (array[i,j]=="@visited@")
                return int.MinValue;
            int counter=1;
            string element=array[i,j];
            array[i,j]="@visited@";
            // Използваме Tuple, за да пазим координатите на посетените елементи в опашката.
            Tuple<int,int> intermediateTuple = Tuple.Create<int,int>(i,j);
            queue.Enqueue(intermediateTuple);
            // Докато не изпразним опашката , взимаме елемент от нея, проверяваме съседите му, и ако съвпадат с търсения го
            // добавяме, променяме стойността им на "@visited@" и увеличаваме брояча с 1 съответно.
            while (queue.Count!=0)
            {
                intermediateTuple=queue.Dequeue();
                if ((intermediateTuple.Item1 - 1 >= 0) && (intermediateTuple.Item1 - 1 < array.GetLength(0))
                    && (0 <= intermediateTuple.Item2) && (intermediateTuple.Item2 < array.GetLength(1))
                    && (array[intermediateTuple.Item1 - 1, intermediateTuple.Item2] == element))
                {
                    array[intermediateTuple.Item1 - 1, intermediateTuple.Item2] = "@visited@";
                    counter++;
                    queue.Enqueue(Tuple.Create<int, int>(intermediateTuple.Item1 - 1, intermediateTuple.Item2));
                }
                if ((intermediateTuple.Item1 + 1 >= 0) && (intermediateTuple.Item1 + 1 < array.GetLength(0))
                    && (0 <= intermediateTuple.Item2) && (intermediateTuple.Item2 < array.GetLength(1))
                    && (array[intermediateTuple.Item1 + 1, intermediateTuple.Item2] == element))
                {
                    array[intermediateTuple.Item1 + 1, intermediateTuple.Item2] = "@visited@";
                    counter++;
                    queue.Enqueue(Tuple.Create<int, int>(intermediateTuple.Item1 + 1, intermediateTuple.Item2));
                }
                if ((intermediateTuple.Item1 >= 0) && (intermediateTuple.Item1 < array.GetLength(0))
                    && (0 <= intermediateTuple.Item2 - 1) && (intermediateTuple.Item2 - 1 < array.GetLength(1))
                    && (array[intermediateTuple.Item1, intermediateTuple.Item2 - 1] == element))
                {
                    array[intermediateTuple.Item1, intermediateTuple.Item2 - 1] = "@visited@";
                    counter++;
                    queue.Enqueue(Tuple.Create<int, int>(intermediateTuple.Item1, intermediateTuple.Item2 - 1));
                }
               if ((intermediateTuple.Item1 >= 0) && (intermediateTuple.Item1 < array.GetLength(0))
                    && (0 <= intermediateTuple.Item2 + 1) && (intermediateTuple.Item2 + 1 < array.GetLength(1))
                    && (array[intermediateTuple.Item1, intermediateTuple.Item2 + 1] == element))
                {
                    array[intermediateTuple.Item1, intermediateTuple.Item2 + 1] = "@visited@";
                    counter++;
                    queue.Enqueue(Tuple.Create<int, int>(intermediateTuple.Item1, intermediateTuple.Item2 + 1));
                }
        }
            // Връщаме брояча.
            return counter;
        }
    }
}
