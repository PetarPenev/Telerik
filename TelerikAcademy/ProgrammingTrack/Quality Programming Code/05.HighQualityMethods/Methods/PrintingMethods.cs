//-----------------------------------------------------------------------
// <copyright file="PrintingMethods.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Methods
{
    using System;

    /// <summary>
    ///     The methods that are associated with conversion and printing on the console.
    /// </summary>
    public static class PrintingMethods
    {
        /// <summary>
        ///     Converts a digit to its text representation.
        /// </summary>
        /// <param name="number">The number to be converted.</param>
        /// <returns><typeparamref name="System.String"/> representation of the digit.</returns>
        public static string DigitToText(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("The number is not a digit.");
            }
        }

        /// <summary>
        ///     Prints a number to the console with decimal precision of 2.
        /// </summary>
        /// <param name="number">The number to be printed.</param>
        public static void PrintWithDecimalPrecisionTwo(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        /// <summary>
        ///     Prints a number on the console as a percentage.
        /// </summary>
        /// <param name="number">The number to be printed.</param>
        public static void PrintAsPercentage(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        /// <summary>
        ///     Prints a number on the console with alignment.
        /// </summary>
        /// <param name="number">The number to be printed.</param>
        public static void PrintWithAlignment(double number)
        {
            Console.WriteLine("{0,8}", number);
        }
    }
}
