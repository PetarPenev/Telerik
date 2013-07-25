using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _07.TextToXml
{
    class Program
    {
        private static string filePath = "../../people.txt";

        private static string xmlFilePath = "../../people.xml";

        private static Encoding encoding = Encoding.GetEncoding("windows-1251");

        static void Main()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    Console.WriteLine("The text file is empty");
                    return;
                }

                using (XmlTextWriter writer = new XmlTextWriter(xmlFilePath, encoding))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("People");
                    writer.WriteAttributeString("name", "People's List");

                    while (line != null)
                    {
                        WritePerson(line, writer);
                        line = reader.ReadLine();
                    }

                    writer.WriteEndDocument();
                }
            }
        }

        public static void WritePerson(string personInfo, XmlWriter writer)
        {
            string[] personAttributes = personInfo.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            writer.WriteStartElement("person");
            writer.WriteElementString("name", personAttributes[0].TrimStart().TrimEnd());
            writer.WriteElementString("address", personAttributes[1].TrimStart().TrimEnd());
            writer.WriteElementString("phone", personAttributes[2].TrimStart().TrimEnd());
            writer.WriteEndElement();
        }
    }
}