namespace ForLoopRefactoring
{
    using System;
    using System.Collections.Generic;

    public class ExecuteForLoop
    {
        public static void Main()
        {
            // Created the necessary variables.
            int[] array = new int[] { 5, 11, 23, 21, 23321, 22, 31, 1, 17, 25 };
            int expectedValue = 25;
            bool valueFound = false;

            for (int index = 0; index < array.Length; index++)
            {
                Console.WriteLine(array[index]);

                // Optimized the conditional statement.
                if ((index % 10 == 0) && (array[index] == expectedValue))
                {
                    valueFound = true;
                    break;
                }
            }

            if (valueFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
