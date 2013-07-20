//-----------------------------------------------------------------------
// <copyright file="FiguresExample.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Abstraction
{
    using System;

    /// <summary>
    ///     A class that shows how different figure classes can be used.
    /// </summary>
    public class FiguresExample
    {
        /// <summary>
        ///     The entry point for the test.
        /// </summary>
        public static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine("I am a circle. " +
                "My perimeter is {0:f2}. My surface is {1:f2}.",
                circle.CalcPerimeter(), circle.CalcSurface());
            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine("I am a rectangle. " +
                "My perimeter is {0:f2}. My surface is {1:f2}.",
                rect.CalcPerimeter(), rect.CalcSurface());
        }
    }
}
