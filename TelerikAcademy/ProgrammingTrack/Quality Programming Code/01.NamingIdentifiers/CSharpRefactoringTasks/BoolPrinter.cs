namespace Tasks
{
    using System;

    public class BoolPrinter
    {
        public const int MaxCount = 6; // never used; could be removed if we decide that it will never be useful

        public class Methods
        {
            public void PrintBoolOnConsole(bool boolVariable)
            {
                string boolToBePrinted = boolVariable.ToString();
                Console.WriteLine(boolToBePrinted);
            }
        }

        public static void Main()
        {
            var instancePrinter = new BoolPrinter.Methods();
            instancePrinter.PrintBoolOnConsole(true);
        }
    }
}
