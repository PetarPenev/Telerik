//-----------------------------------------------------------------------
// <copyright file="MathUtilities.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    ///     Contains different mathematical methods.
    /// </summary>
    /// <remarks>
    ///     Removed static fields (not a good practice) and the methods associated with them. Created different
    ///     other methods to compensate for the lost functionality.
    /// </remarks>
    public static class MathUtilities
    {       
        /// <summary>
        ///     Calculating the distance between two points in two-dimensional Cartesian space.
        /// </summary>
        /// <param name="x1">The X coordinate of the first point.</param>
        /// <param name="y1">The Y coordinate of the first point.</param>
        /// <param name="x2">The X coordinate of the second point.</param>
        /// <param name="y2">The Y coordinate of the second point.</param>
        /// <returns><typeparamref name="System.Double"/> value of the distance between the points.</returns>
        public static double CalculateDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        /// <summary>
        ///     Calculating the distance between two points in two-dimensional Cartesian space.
        /// </summary>
        /// <param name="x1">The X coordinate of the first point.</param>
        /// <param name="y1">The Y coordinate of the first point.</param>
        /// <param name="z1">The Z coordinate of the first point.</param>
        /// <param name="x2">The X coordinate of the second point.</param>
        /// <param name="y2">The Y coordinate of the second point.</param>
        /// <param name="z2">The Z coordinate of the second point.</param>
        /// <returns><typeparamref name="System.Double"/> value of the distance between the points.</returns>
        public static double CalculateDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));

            return distance;
        }

        /// <summary>
        ///     Calculates the volume of a parallelepiped.
        /// </summary>
        /// <param name="width">The width of the parallelepiped.</param>
        /// <param name="height">The height of the parallelepiped.</param>
        /// <param name="depth">The depth of the parallelepiped.</param>
        /// <returns><typeparamref name="System.Double"/> value of the volume of the parallelepiped.</returns>
        public static double CalculateParallelepipedVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;

            return volume;
        }

        /// <summary>
        ///     Calculates the volume of a cylinder.
        /// </summary>
        /// <param name="radius">The radius of the base of the cylinder.</param>
        /// <param name="height">The height of the cylinder.</param>
        /// <returns><typeparamref name="System.Double"/> value of the volume of the cylinder.</returns>
        public static double CalculateCylinderVolume(double radius, double height)
        {
            double volume = Math.PI * radius * height * height;

            return volume;
        }

        /// <summary>
        ///     Calculates the volume of a cone.
        /// </summary>
        /// <param name="radius">The radius of the base of the cone.</param>
        /// <param name="height">The height of the cone.</param>
        /// <returns><typeparamref name="System.Double"/> value of the volume of the cone.</returns>
        public static double CalculateConeVolume(double radius, double height)
        {
            double volume = (Math.PI * radius * radius) * height / 3;

            return volume;
        }

        /// <summary>
        ///     Calculates the volume of a sphere.
        /// </summary>
        /// <param name="radius">The radius of the sphere.</param>
        /// <returns><typeparamref name="System.Double"/> value of the volume of the sphere.</returns>
        public static double CalculateSphereVolume(double radius)
        {
            double volume = 4 / 3 * Math.PI * radius;

            return volume;
        }
    }
}
