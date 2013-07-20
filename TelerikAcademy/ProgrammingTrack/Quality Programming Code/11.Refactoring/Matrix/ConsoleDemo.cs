namespace LinearAlgebra
{
    using System;

    public static class ConsoleDemo
    {
        public static void Main()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int dimensions = 0;
            while (!int.TryParse(input, out dimensions) || dimensions < 0 || dimensions > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number in the range [0, 100).");
                input = Console.ReadLine();
            }

            Matrix matrix = new Matrix(dimensions);
            matrix.Traverse();
            Console.WriteLine(matrix.ToString());
        }
    }
}
