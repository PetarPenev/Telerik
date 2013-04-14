using System;
using System.Collections.Generic;

namespace _09.DepthFirstSearch
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
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            int maxSequence=int.MinValue, currentSequence=0;
            // За всеки елемент викаме FindSequence и сравняваме резултата с максималната последователност.
            for (int i=0; i<array.GetLength(0);i++)
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    currentSequence = FindSequence(i, j, stack, array);
                    if (currentSequence > maxSequence)
                        maxSequence = currentSequence;
                }
            Console.WriteLine(maxSequence);
        }

        static int FindSequence(int i, int j, Stack<Tuple<int, int>> stack, string[,] array)
        {
            // Отново можем да върнем произовлно число <= maxSequence, ако елементът е вече посетен.
            if (array[i, j] == "@visited@")
                return int.MinValue;
            // Отново пазим координатите в Tuple.
            Tuple<int, int> intermediateTuple = Tuple.Create<int, int>(i, j);
            // Този път използваме стек.
            stack.Push(intermediateTuple);
            string element = array[i, j];
            array[i, j] = "@visited@";
            int counter = 1;
            while (stack.Count != 0)
            {
                // Взимаме елемент от стека и проверяваме дали някой от съседите му е търсеният. Ако да, то го променяме
                // и връщаме и двата елемента в стека. Ако не, то просто разглежданият елемент не се връща в стека. 
                //Това продължава, докато стека не се изпразни.
                intermediateTuple = stack.Pop();
                if ((intermediateTuple.Item1 - 1 >= 0) && (intermediateTuple.Item1 - 1 < array.GetLength(0))
                    && (0 <= intermediateTuple.Item2) && (intermediateTuple.Item2 < array.GetLength(1))
                    && (array[intermediateTuple.Item1 - 1, intermediateTuple.Item2] == element))
                {
                    array[intermediateTuple.Item1 - 1, intermediateTuple.Item2] = "@visited@";
                    counter++;
                    stack.Push(intermediateTuple);
                    intermediateTuple = Tuple.Create<int, int>(intermediateTuple.Item1 - 1, intermediateTuple.Item2);
                    stack.Push(intermediateTuple);
                }
                else if ((intermediateTuple.Item1 + 1 >= 0) && (intermediateTuple.Item1 + 1 < array.GetLength(0))
                    && (0 <= intermediateTuple.Item2) && (intermediateTuple.Item2 < array.GetLength(1))
                    && (array[intermediateTuple.Item1 + 1, intermediateTuple.Item2] == element))
                {
                    array[intermediateTuple.Item1 + 1, intermediateTuple.Item2] = "@visited@";
                    counter++;
                    stack.Push(intermediateTuple);
                    intermediateTuple = Tuple.Create<int, int>(intermediateTuple.Item1 + 1, intermediateTuple.Item2);
                    stack.Push(intermediateTuple);
                }
                else if ((intermediateTuple.Item1 >= 0) && (intermediateTuple.Item1 < array.GetLength(0))
                    && (0 <= intermediateTuple.Item2 - 1) && (intermediateTuple.Item2 - 1 < array.GetLength(1))
                    && (array[intermediateTuple.Item1, intermediateTuple.Item2 - 1] == element))
                {
                    array[intermediateTuple.Item1, intermediateTuple.Item2 - 1] = "@visited@";
                    counter++;
                    stack.Push(intermediateTuple);
                    intermediateTuple = Tuple.Create<int, int>(intermediateTuple.Item1, intermediateTuple.Item2 - 1);
                    stack.Push(intermediateTuple);
                }
                else if ((intermediateTuple.Item1 >= 0) && (intermediateTuple.Item1 < array.GetLength(0))
                    && (0 <= intermediateTuple.Item2 + 1) && (intermediateTuple.Item2 + 1 < array.GetLength(1))
                    && (array[intermediateTuple.Item1, intermediateTuple.Item2 + 1] == element))
                {
                    array[intermediateTuple.Item1, intermediateTuple.Item2 + 1] = "@visited@";
                    counter++;
                    stack.Push(intermediateTuple);
                    intermediateTuple = Tuple.Create<int, int>(intermediateTuple.Item1, intermediateTuple.Item2 + 1);
                    stack.Push(intermediateTuple);
                }

            }
            // Връщаме брояча.
            return counter;
        }    
    }
}
