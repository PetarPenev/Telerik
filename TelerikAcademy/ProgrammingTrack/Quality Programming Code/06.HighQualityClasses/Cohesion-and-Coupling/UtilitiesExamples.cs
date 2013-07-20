//-----------------------------------------------------------------------
// <copyright file="UtilitiesExamples.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    ///     Class demonstrating how the different static methods form the utilities classes can be used.
    /// </summary>
    public class UtilitiesExamples
    {
        /// <summary>
        ///     The entry point for the test.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine(FileUtilities.GetFileExtension("example"));
            Console.WriteLine(FileUtilities.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtilities.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                MathUtilities.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                MathUtilities.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            Console.WriteLine("Volume of parallelepiped = {0:f2}", MathUtilities.CalculateParallelepipedVolume(3, 4, 5));
            Console.WriteLine("Volume of cylinder = {0:f2}", MathUtilities.CalculateCylinderVolume(3, 4));
            Console.WriteLine("Volume of cone = {0:f2}", MathUtilities.CalculateConeVolume(3, 4));
            Console.WriteLine("Volume of sphere = {0:f2}", MathUtilities.CalculateSphereVolume(3));
        }
    }
}
