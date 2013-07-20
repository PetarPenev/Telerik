//-----------------------------------------------------------------------
// <copyright file="Rectangle.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Abstraction
{
    using System;

    /// <summary>
    ///     A class representing a rectangle.
    /// </summary>
    public class Rectangle : Figure
    {
        /// <summary>
        ///     The width of the rectangle.
        /// </summary>
        private double width;

        /// <summary>
        ///     The height of the rectangle.
        /// </summary>
        private double height;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Rectangle" /> class.
        /// </summary>
        /// <param name="width"><typeparamref name="System.Double"/> value of the width.</param>
        /// <param name="height"><typeparamref name="System.Double"/> value of the height.</param>
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width must be a positive number.");
                }

                this.width = value;
            }
        }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The height must be a positive number.");
                }

                this.height = value;
            }
        }

        /// <summary>
        ///     Calculates the perimeter of the rectangle.
        /// </summary>
        /// <returns><typeparamref name="System.Double"/> value of the perimeter.</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        /// <summary>
        ///     Calculates the surface of the rectangle.
        /// </summary>
        /// <returns><typeparamref name="System.Double"/> value of the surface.</returns>
        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;

            return surface;
        }
    }
}
