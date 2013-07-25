using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _10.DirectoryTraversalWithXDocument
{
    class Program
    {
        // I have used a static file path. Feel free to change it.
        private static string directoryPath = "d:\\CommercialBanking";

        private static string outputFilePath = "../../directories.xml";

        private static Encoding encoding = Encoding.GetEncoding("windows-1251");

        static void Main()
        {
            XDocument document = new XDocument();
            document.Declaration = new XDeclaration("1.0", "windows-1251", "yes");
            var rootElement = new XElement("directories");
            rootElement.Add(new XAttribute("name", "Directories' List"));
            document.Add(rootElement);
            var mainDirectory = new XElement("directory", new XElement("name", FormatPathString(directoryPath)));
            rootElement.Add(mainDirectory);
            TraverseDirectory(mainDirectory, directoryPath);
            document.Save(outputFilePath);
        }

        private static void TraverseDirectory(XElement parentElement, string path)
        {
            var currentDirectories = Directory.EnumerateDirectories(path);

            foreach (var directory in currentDirectories)
            {
                XElement directoryXmlTag = new XElement("directory", new XElement("name", FormatPathString(directory)));
                parentElement.Add(directoryXmlTag);
                TraverseDirectory(directoryXmlTag, directory);
            }

            var currentFiles = Directory.EnumerateFiles(path);

            foreach (var file in currentFiles)
            {
                parentElement.Add(new XElement("file", FormatPathString(file)));
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