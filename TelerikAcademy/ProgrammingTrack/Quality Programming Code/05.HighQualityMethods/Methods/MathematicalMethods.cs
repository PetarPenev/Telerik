//-----------------------------------------------------------------------
// <copyright file="MathematicalMethods.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Methods
{
    using System;

    /// <summary>
    ///     Class containing all the methods associated with different math operations.
    /// </summary>
    public static class MathematicalMethods
    {
        /// <summary>
        ///     Calculates the area of a triangle.
        /// </summary>
        /// <param name="a">First side of the triangle.</param>
        /// <param name="b">Second side of the triangle.</param>
        /// <param name="c">Third side of the triangle.</param>
        /// <returns>The area of the triangle.</returns>
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("All sides must be positive numbers.");
            }

            if (!IsValidTriangle(a, b, c))
            {
                throw new ArgumentException("The sides cannot form a triangle.");
            }

            double semiPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

            return area;
        }

        /// <summary>
        ///     Checks whether the triangle can be formed with the specified sides.
        /// </summary>
        /// <param name="a">First side of the triangle.</param>
        /// <param name="b">Second side of the triangle.</param>
        /// <param name="c">Third side of the triangle.</param>
        /// <returns><typeparamref name="System.Bool"/> value indicating whether the triangle can be formed.</returns>
        public static bool IsValidTriangle(double a, double b, double c)
        {
            // The triangle can exist only if the sum of the lengths of any two sides exceeds 
            // the length of the third side. 
            bool canFormTriangle = (a + b > c) && (b + c > a) && (a + c > b);

            return canFormTriangle;
        }

        /// <summary>
        ///     Finds the larges value in an integer array.
        /// </summary>
        /// <param name="elements">The array of integer numbers.</param>
        /// <returns>The largest value in the integer array.</returns>
        public static int MaxNumber(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentException("The array of elements is not initialized.");
            }
            else if (elements.Length == 0)
            {
                throw new ArgumentException("The array of elements is empty.");
            }

            // Introducing new parameter in order not to change the input and introduce
            // unnecessary and unwanted side effects.
            int maxValue = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxValue)
                {
                    maxValue = elements[i];
                }
            }

            return maxValue;
        }

        /// <summary>
        ///     Calculates the distance between two points in a 2-dimensional
        ///     Cartesian space. Also returns as out parameters whether
        ///     they form a vertical or a horizontal line.
        /// </summary>
        /// <param name="x1">X coordinate of the first point.</param>
        /// <param name="y1">Y coordinate of the first point.</param>
        /// <param name="x2">X coordinate of the second point.</param>
        /// <param name="y2">Y coordinate of the second point.</param>
        /// <param name="isHorizontal"><typeparamref name="System.Bool"/> indicating whether the points 
        /// are on a horizontal line.</param>
        /// <param name="isVertical"><typeparamref name="System.Bool"/> indicating whether the points 
        /// are on a vertical line.</param>
        /// <returns><typeparamref name="System.Double"/> value of the distance between the points.</returns>
        public static double CalcDistance(double x1, double y1, double x2, double y2,
            out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = IsLine(y1, y2);
            isVertical = IsLine(x1, x2);

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        /// <summary>
        ///     Checks whether the values of the two coordinates are equal and therefore they
        ///     are on a line that is parallel to an axis.
        /// </summary>
        /// <param name="firstCoordinate">Coordinate of the first point.</param>
        /// <param name="secondCoordinate">Coordinate of the second point.</param>
        /// <returns><typeparamref name="System.Bool"/> indicating whether the line connecting 
        /// the points is parallel to an axis.</returns>
        public static bool IsLine(double firstCoordinate, double secondCoordinate)
        {
            bool isLine = firstCoordinate == secondCoordinate;

            return isLine;
        }
    }
}
