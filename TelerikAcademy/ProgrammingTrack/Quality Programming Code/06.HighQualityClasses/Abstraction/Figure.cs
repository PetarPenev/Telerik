//-----------------------------------------------------------------------
// <copyright file="Figure.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Abstraction
{
    using System;

    /// <summary>
    ///     The abstract class figure that is going to be the basis for all figures implemented in the task.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        ///     An abstract method that will calculate the perimeter of the figure.
        /// </summary>
        /// <returns><typeparamref name="System.Double"/> value of the perimeter.</returns>
        public abstract double CalculatePerimeter();

        /// <summary>
        ///     An abstract method that will calculate the surface of the figure.
        /// </summary>
        /// <returns><typeparamref name="System.Double"/> value of the surface.</returns>
        public abstract double CalculateSurface();
    }
}
