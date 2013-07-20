namespace _10.ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShortestSequenceOfOperations
    {
        public static int GetNumberInput()
        {
            string inputLine = Console.ReadLine();
            int numberToReturn = 0;
            bool isValidNumber = int.TryParse(inputLine, out numberToReturn);

            while (!isValidNumber)
            {
                Console.WriteLine("Please enter a valid integer number.");
                isValidNumber = int.TryParse(Console.ReadLine(), out numberToReturn);
            }

            return numberToReturn;
        }

        public static Queue<int> GetShortestSequence(int start, int end)
        {
            // The general algorithm is simple. First, we take care for the cases when the number is negative.
            // Then, we take care of cases like n=1, m=3 where you should just add 2.
            // Then we double the current number until we reach the point where we cannot double it any more
            // or if we double it again, we will have to reach the end via incrementing only. Then we check whether we can increment
            // a number of times and reach the end by single doubling after that or we should just increment - and use the two cases as a 
            // way to reach the end.
            int currentNumber = start;
            int currentEnd = end;
            Queue<int> shortestSequence = new Queue<int>();
            shortestSequence.Enqueue(start);

            while (currentNumber <= 0)
            {
                if (currentNumber == currentEnd)
                {
                    return shortestSequence;
                }

                if (currentNumber + 1 == currentEnd)
                {
                    currentNumber++;
                    shortestSequence.Enqueue(currentNumber);
                    return shortestSequence;
                }
                else
                {
                    currentNumber += 2;
                    shortestSequence.Enqueue(currentNumber);
                }
            }

            if (currentEnd - currentNumber == 2)
            {
                currentNumber += 2;
                shortestSequence.Enqueue(currentNumber);
            }

            if (currentNumber != 0)
            {
                while (currentNumber * 2 <= currentEnd / 2)
                {
                    currentNumber *= 2;
                    shortestSequence.Enqueue(currentNumber);
                }
            }

            if (currentNumber != currentEnd)
            {
                if (currentEnd / 2 < currentNumber)
                {
                    while (currentNumber + 2 <= currentEnd)
                    {
                        currentNumber += 2;
                        shortestSequence.Enqueue(currentNumber);
                    }

                    while (currentNumber + 1 <= currentEnd)
                    {
                        currentNumber++;
                        shortestSequence.Enqueue(currentNumber);
                    }
                }
                else
                {
                    int intermediateEnd = currentEnd / 2;

                    while (currentNumber + 2 <= intermediateEnd)
                    {
                        currentNumber += 2;
                        shortestSequence.Enqueue(currentNumber);
                    }

                    while (currentNumber + 1 <= intermediateEnd)
                    {
                        currentNumber++;
                        shortestSequence.Enqueue(currentNumber);
                    }

                    currentNumber *= 2;
                    shortestSequence.Enqueue(currentNumber);

                    // This is the case where we have an odd number (like 21) that must be reached by adding additional 1.
                    if (currentNumber < currentEnd)
                    {
                        currentNumber++;
                        shortestSequence.Enqueue(currentNumber);
                    }
                }
            }

            return shortestSequence;
        }

        public static void PrintQueue(Queue<int> sequenceToPrint)
        {
            Console.WriteLine("The sequence is:");
            while (sequenceToPrint.Count != 0)
            {
                Console.Write("{0} ", sequenceToPrint.Dequeue());
            }
        }

        public static void Main()
        {
            Console.WriteLine("Please enter n.");
            int startNumber = GetNumberInput();

            Console.WriteLine("Please enter m.");
            int endNumber = GetNumberInput();

            if (endNumber < startNumber)
            {
                Console.WriteLine("The number is unreachable with the allowed operations.");
            }
            else if (endNumber == startNumber)
            {
                Console.WriteLine("The numbers are already equal.");
            }
            else
            {
                Queue<int> shortestSequence = GetShortestSequence(startNumber, endNumber);
                PrintQueue(shortestSequence);
            }
        }
    }
}
