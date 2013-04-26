using System;
using System.Text;

namespace Library
{
    // 1 Task - Implementing substring for stringbuilder
    public static class ExtensionsStringBuilder
    {
        public static StringBuilder Substring(this StringBuilder str, int startPosition)
        {
            // Throwing an exception if the start position is outside the size of the string
            if ((str.Length <= startPosition) || (startPosition<0))
                throw new IndexOutOfRangeException("Start index larger than the length of input string.");
            StringBuilder returnStr = new StringBuilder();
            returnStr.Append(str.ToString().Substring(startPosition));
            return returnStr;
        }

        public static StringBuilder Substring(this StringBuilder str, int startPosition, int length)
        {
            // Throwing an exception if the start position is outside the size of the string or if the 
            // length exceeeds the remaining characters.
            if ((str.Length <= startPosition) || (startPosition<0))
                throw new IndexOutOfRangeException("Start index larger than the length of input string.");
            if (str.Length <= startPosition + length)
                throw new IndexOutOfRangeException("The length of the substring exceeds the characters of the StringBuilder after the start index.");
            StringBuilder returnStr = new StringBuilder();
            returnStr.Append(str.ToString().Substring(startPosition, length));
            return returnStr;
        }
    }
}
