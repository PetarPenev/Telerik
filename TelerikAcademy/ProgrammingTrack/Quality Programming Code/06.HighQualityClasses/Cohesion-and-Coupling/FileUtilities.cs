//-----------------------------------------------------------------------
// <copyright file="FileUtilities.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    ///     A static class containing different methods for extracting file names and extensions.
    /// </summary>
    public static class FileUtilities
    {
        /// <summary>
        ///     A methods that returns the extension of a given file name.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The file extension</returns>
        /// <remarks>Returns <see cref="string.Empty"/> if the file name does not contain an extension.</remarks>
        public static string GetFileExtension(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("The file name is not initialized.");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        /// <summary>
        ///     A method that returns the name (extension removed) of a given file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The file name with the extension removed.</returns>
        public static string GetFileNameWithoutExtension(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("The file name is not initialized.");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
