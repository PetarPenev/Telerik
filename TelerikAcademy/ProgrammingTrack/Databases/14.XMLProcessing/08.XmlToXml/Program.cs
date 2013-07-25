using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _08.XmlToXml
{
    class Program
    {
        private static string filePath = "../../../catalogue.xml";

        private static string outputFilePath = "../../albums.xml";

        private static Encoding encoding = Encoding.GetEncoding("windows-1251");

        static void Main()
        {
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                using (XmlTextWriter writer = new XmlTextWriter(outputFilePath, encoding))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("Albums");
                    writer.WriteAttributeString("name", "Album's List");

                    bool hasWrittenAlbum = false;

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "album")
                            {
                                if (hasWrittenAlbum)
                                {
                                    writer.WriteEndElement();
                                }

                                hasWrittenAlbum = true;
                                writer.WriteStartElement("album");
                            }
                            else if (reader.Name == "name")
                            {
                                writer.WriteElementString("name", reader.ReadElementString());
                            }
                            else if (reader.Name == "artist")
                            {
                                writer.WriteElementString("artist", reader.ReadElementString());
                            }
                        }
                    }

                    writer.WriteEndDocument();
                }
            }
        }
    }
}