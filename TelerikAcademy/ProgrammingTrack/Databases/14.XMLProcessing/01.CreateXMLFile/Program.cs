using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

// Please run this before executing the other projects. It will (re)generate the xml catalogue file necessary for the
// other tasks. Also, please do not delete the xsl file in the main project category - it is necessary for task 14.
namespace _01.CreateXMLFile
{
    class Program
    {
        private static CultureInfo culture = CultureInfo.GetCultureInfo("en-Us");

        private static Encoding encoding = Encoding.GetEncoding("windows-1251");

        private static string filePath = "../../../catalogue.xml";  

        static void Main()
        {                   
            using (XmlTextWriter writer = new XmlTextWriter(filePath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
        
                writer.WriteStartDocument();
                writer.WriteStartElement("catalogue");
                writer.WriteAttributeString("name", "My Catalogue");

                WriteAlbum(writer, "True Self", "Soil", 2006, "DRT Entertainment", 25);

                WriteAlbum(writer, "Construct", "Dark Tranquility", 2013, "Century Media", 10.5m,
                    new List<string>() { "The Science Of Noise", "Uniformity", "Endtime Hearts" });

                WriteAlbum(writer, "Damage Done", "Dark Tranquility", 2002, "Century Media", 22);

                WriteAlbum(writer, "Strap It On", "Helmet", 1990, "Amphetamine Reptile", 12.5m,
                    new List<string>() { "Bad Mood", "Rude" });

                WriteAlbum(writer, "Redefine", "Soil", 2004, "J Records", 8);              
                    
                writer.WriteEndDocument();
            }
            Console.WriteLine("Document {0} created.", filePath);
        }

        private static void WriteAlbum(XmlWriter writer, string name, string artist, short year, string producer,
            decimal price, List<string> songs = null)
        {
            if (year > 2013)
            {
                throw new ArgumentOutOfRangeException("Impossible year value.");
            }

            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Impossible price value.");
            }

            writer.WriteStartElement("album");
            writer.WriteElementString("name", name);
            writer.WriteElementString("artist", artist);
            writer.WriteElementString("year", year.ToString());
            writer.WriteElementString("producer", producer);
            writer.WriteElementString("price", string.Format(culture, "{0:C}", price));
            if ((songs != null) && (songs.Count > 0))
            {
                writer.WriteStartElement("songs");
                foreach (var song in songs)
                {
                    writer.WriteElementString("song", song);
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}