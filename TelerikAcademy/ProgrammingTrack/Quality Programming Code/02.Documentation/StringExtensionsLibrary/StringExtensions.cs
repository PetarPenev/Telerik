//-----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Contains different extension methods for the <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Returns the MD5 hash value of the given string.
        /// </summary>
        /// <param name="input">
        ///     The string whose hash value is to be computed. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string inputToTransform = "Football pitch";
        ///         Console.WriteLine(inputToTransform.ToMd5Hash());
        ///     </code>
        /// </example>
        /// <returns>
        ///     The <see cref="System.String"/> MD5 (128-bit) hash value of the string.
        /// </returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        ///     Check whether the string value can be interpreted to mean 
        ///     a "true" <see cref="System.Boolean"/> value.
        /// </summary>
        /// <param name="input">
        ///     The string to be interpreted. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string booleanInput = "ok";
        ///         Console.WriteLine(booleanInput.ToBoolean());
        ///     </code>
        /// </example>
        /// <returns>
        ///     Return true if the string can be interpreted to mean
        ///     a "true" <see cref="System.Boolean"/> value.
        /// </returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        ///     Converts the string to a <see cref="System.Int16"/> value.
        /// </summary>
        /// <param name="input">
        ///     The string to be converted. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string shortValue = "243";
        ///         Console.WriteLine(shortValue.ToShort());
        ///     </code>
        /// </example>
        /// <returns>
        ///     The <see cref="System.Int16"/> value of the original string.
        /// </returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        ///     Converts the string to a <see cref="System.Int32"/> value.
        /// </summary>
        /// <param name="input">
        ///     The string to be converted. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string integerValue = "3756";
        ///         Console.WriteLine(integerValue.ToInteger());
        ///     </code>
        /// </example>
        /// <returns>
        ///     The <see cref="System.Int32"/> value of the original string.
        /// </returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        ///     Converts the string to a <see cref="System.Int64"/> value.
        /// </summary>
        /// <param name="input">
        ///     The string to be converted. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string longValue = "11";
        ///         Console.WriteLine(longValue.ToLong());
        ///     </code>
        /// </example>
        /// <returns>
        ///     The <see cref="System.Int64"/> value of the original string.
        /// </returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        ///     Converts the string to a <see cref="System.DateTime"/> value.
        /// </summary>
        /// <param name="input">
        ///     The string to be converted. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string date = ""Fri, 15 May 2009 20:10:57 GMT";
        ///         Console.WriteLine(date.ToDateTime());
        ///     </code>
        /// </example>
        /// <returns>
        ///     The <see cref="System.DateTime"/> value of the original string.
        /// </returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        ///     Returns a copy of the string with a 
        ///     capitalized first letter (if the string is not null or empty).
        /// </summary>
        /// <param name="input">
        ///     The string to be transformed. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string nameToCapitalize = "nikodim";
        ///         Console.WriteLine(nameToCapitalize.CapitalizeFirstLetter());
        ///     </code>
        /// </example>
        /// <returns>
        ///     A <see cref="System.String"/> value equivalent to the input with 
        ///     capitalized first letter.
        /// </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        ///     Returns a substring from the original string that is between
        ///     the <paramref name="startString"/> and <paramref name="endString"/>.
        ///     Search starts from the <paramref name="startFrom"/> index.
        /// </summary>
        /// <param name="input">
        ///     The string to be searched. See example.
        /// </param>
        /// <param name="startString">
        ///     The string that should precede the result string.
        /// </param>
        /// <param name="endString">
        ///     The string that should follow the result string.
        /// </param>
        /// <param name="startFrom">
        ///     An optional parameter for the position in the input string to start the search from.
        ///     Default value (if unspecified) is 0.
        /// </param>
        /// <example>
        ///     <code>
        ///         string stringToSearch = "BestTelerikAcademyStudents";
        ///         string startString = "Telerik";
        ///         string endString = "Students";
        ///         int startFrom = 4;
        ///         Console.WriteLine(stringToSearch.GetStringBetween(startString, endString, startFrom));
        ///     </code>
        /// </example>
        /// <returns>
        ///     Returns a <see cref="System.String"/> that is the substring from the original string between 
        ///     the <paramref name="startString"/> and the <paramref name="endString"/>
        ///     strings. Returns System.String.Empty if the original string does not contain
        ///     the <paramref name="startString"/> or <paramref name="endString"/>.
        /// </returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        ///     Replaces all Cyrillic lower- and uppercase letters in the input string
        ///     with their Latin representation.
        /// </summary>
        /// <param name="input">
        ///     The string to be modified. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string nameToConvertToLatin = "Евстати";
        ///         Console.WriteLine(nameToConvertToLatin.ConvertCyrillicToLatinLetters());
        ///     </code>
        /// </example>
        /// <returns>
        ///     A <see cref="System.String"/> copy of the string with all the Cyrillic lower- and uppercase letter replaced
        ///     with their Latin representation.
        /// </returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        ///     Replaces all Latin lower- and uppercase letters in the input string
        ///     with their Cyrillic representation.
        /// </summary>
        /// <param name="input">
        ///     The string to be modified. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string nameToConvertToCyrillic = "Natanail";
        ///         Console.WriteLine(nameToConvertToCyrillic.ConvertLatinToCyrillicKeyboard());
        ///     </code>
        /// </example>
        /// <returns>
        ///     A <see cref="System.String"/> copy of the string with all the Latin lower- and uppercase letter replaced
        ///     with their Cyrillic representation.
        /// </returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        ///     Converts the input string to a valid username by replacing all Cyrillic with Latin letters
        ///     and removing non-alphanumeric characters (with the exception of '.') by replacing them
        ///     with an empty string.
        /// </summary>
        /// <param name="input">
        ///     The string to be converted to a valid username. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string usernameToValidate = "Румпелщилцким13.2";
        ///         Console.WriteLine(usernameToValidate.ToValidUsername());
        ///     </code>
        /// </example>
        /// <returns>
        ///     A <see cref="System.String"/> version of the original string with the appropriate conversion of 
        ///     Cyrillic to Latin letters and with non-alphanumeric characters ('.' excluded) removed.
        /// </returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        ///     Converts the input string (representing a file name) to a valid Latin file name
        ///     by replacing all Cyrillic with latin letters, replacing spaces with hyphens and 
        ///     removing all non-alphanumeric characters (excluding '.' and '-') by replacing
        ///     them with <see cref="System.String.Empty"/>
        /// </summary>
        /// <param name="input">
        ///     The string to be transformed to a valid Latin file name. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string fileNameToValidate = "Каталог 2013";
        ///         Console.WriteLine(fileNameToValidate.ToValidLatinFileName());
        ///     </code>
        /// </example>
        /// <returns>
        ///     A <see cref="System.String"/> copy of the original string with replaced Cyrillic letters,
        ///     spaces replaced with hyphens and non-alphanumeric characters (excluding '.' and '-') removed.
        /// </returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        ///     Returns the first <paramref name="charsCount"/> characters of the given string.
        /// </summary>
        /// <param name="input">
        ///     The string whose first <paramref name="charsCount"/> characters are to be returned. See example.
        /// </param>
        /// <param name="charsCount">
        ///     The number of characters that are to be returned.
        /// </param>
        /// <example>
        ///     <code>
        ///         string nameToShorted = "Tankoverhaul";
        ///         Console.WriteLine(nameToShorten.GetFirstCharacters(4));
        ///     </code>
        /// </example>
        /// <returns>
        ///     Returns a <see cref="System.String"/> containing the first <paramref name="charsCount"/>
        ///     characters of the given string or the whole string if <paramref name="charsCount"/> is 
        ///     larger than the length of the <paramref name="input"/> string.
        /// </returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        ///     Returns the file extension of the <paramref name="fileName"/> input parameter.
        /// </summary>
        /// <param name="fileName">
        ///     The string (representing a file name) whose extension is to be returned. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string nameOfFile = "dubstep.mp3";
        ///         Console.WriteLine(nameOfFile.GetFileExtension());
        ///     </code>
        /// </example>
        /// <returns>
        ///     Returns a <see cref="System.String"/> that is the file extension or a <see cref="System.String.Empty"/>
        ///     if the file name is null, whitespace or does not have an extension.
        /// </returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        ///     Returns the content type that corresponds to the <paramref name="fileExtension"/> extension.
        /// </summary>
        /// <param name="fileExtension">
        ///     The file extension. See example.
        /// </param>
        /// <example>
        ///     <code>
        ///         string fileExtension = "pdf";
        ///         Console.WriteLine(fileExtension.ToContentType());
        ///     </code>
        /// </example>
        /// <returns>
        ///     The <see cref="System.String"/> content type corresponding to the extension. If the extension is unfamiliar,
        ///     <see cref="System.String"/> "application/octet-stream" is returned.
        /// </returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        ///     Converts the characters of the <paramref name="input"/> to a byte array.
        /// </summary>
        /// <param name="input">
        ///     <see cref="System.String"/> whose characters are to be converted. See example
        /// </param>
        /// <example>
        ///     <code>
        ///         string charactersToConvertToByte = "Fred";
        ///         byte[] arrayOfByteRepresentations = charactersToConvertToByte.ToByteArray();
        ///     </code>
        /// </example>
        /// <returns>
        ///     A byte array containing the representation of the characters.
        /// </returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}