//-----------------------------------------------------------------------
// <copyright file="Methods.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Methods
{
    using System;

    /// <summary>
    ///     The console app class used for testing.
    /// </summary>
    public class Methods
    {     
        /// <summary>
        ///  The Main methods that calls different methods in order to test them.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine(MathematicalMethods.CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(PrintingMethods.DigitToText(5));
            
            Console.WriteLine(MathematicalMethods.MaxNumber(5, -1, 3, 2, 14, 2, 3));
            
            PrintingMethods.PrintWithDecimalPrecisionTwo(1.3);
            PrintingMethods.PrintAsPercentage(0.75);
            PrintingMethods.PrintWithAlignment(2.30);

            bool horizontal, vertical;
            Console.WriteLine(MathematicalMethods.CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Petar", "Ivanov", new DateTime(1992, 3, 17)); 

            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3)); 

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
