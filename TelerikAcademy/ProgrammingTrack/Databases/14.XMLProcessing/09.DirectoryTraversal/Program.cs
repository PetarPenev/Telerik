using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _09.DirectoryTraversal
{
    class Program
    {
        // I have used a static file path. Feel free to change it.
        private static string directoryPath = "d:\\CommercialBanking";

        private static string outputFilePath = "../../directories.xml";

        private static Encoding encoding = Encoding.GetEncoding("windows-1251");

        static void Main()
        {
            using (XmlTextWriter writer = new XmlTextWriter(outputFilePath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directories");
                writer.WriteAttributeString("name", "Directories' List");

                writer.WriteStartElement("directory");
                writer.WriteElementString("name", FormatPathString(directoryPath));
                TraverseDirectory(writer, directoryPath);

                writer.WriteEndDocument();
            }
        }

        private static void TraverseDirectory(XmlWriter writer, string path)
        {
            var currentDirectories = Directory.EnumerateDirectories(path);
            
            foreach (var directory in currentDirectories)
            {
                writer.WriteStartElement("directory");
                writer.WriteElementString("name", FormatPathString(directory));
                TraverseDirectory(writer, directory);
                writer.WriteEndElement();
            }

            var currentFiles = Directory.EnumerateFiles(path);

            foreach (var file in currentFiles)
            {
                writer.WriteElementString("file", FormatPathString(file));
            }
        }

        private static string FormatPathString(string path)
        {
            string pathCopy = String.Copy(path);

            int lastIndexOfDirectorySign = path.LastIndexOf('\\');
            if (lastIndexOfDirectorySign != -1)
            {
                pathCopy = path.Substring(lastIndexOfDirectorySign + 1);
            }

            return pathCopy;
        }
    }
}