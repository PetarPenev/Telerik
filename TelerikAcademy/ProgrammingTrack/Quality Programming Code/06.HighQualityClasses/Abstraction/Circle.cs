//-----------------------------------------------------------------------
// <copyright file="Circle.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Abstraction
{
    using System;

    /// <summary>
    ///     A class representing a circle.
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        ///     The radius of the circle.
        /// </summary>
        private double radius;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Circle" /> class.
        /// </summary>
        /// <param name="radius"><typeparamref name="System.Double"/> value of the radius.</param>
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        /// <summary>
        ///     Gets or sets the radius of the circle.
        /// </summary>
        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The radius must be a positive number.");
                }

                this.radius = value;
            }
        }

        /// <summary>
        ///     Calculates the perimeter of the circle.
        /// </summary>
        /// <returns><see cref="System.Double"/> value of the perimeter.</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        /// <summary>
        ///     Calculates the surface of the circle.
        /// </summary>
        /// <returns><see cref="System.Double"/> value of the surface.</returns>
        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;

            return surface;
        }
    }
}
