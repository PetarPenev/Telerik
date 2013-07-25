using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _05.ExtractSongTitles
{
    class Program
    {
        private static string filePath = "../../../catalogue.xml";

        static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load(filePath);
            List<string> listOfSongs = new List<string>();

            foreach (XmlNode node in document.DocumentElement.ChildNodes)
            {
                if (node["songs"] != null)
                {
                    foreach (XmlNode song in node["songs"].ChildNodes)
                    {
                        listOfSongs.Add(song.InnerText);
                    }
                }
            }

            foreach (var song in listOfSongs)
            {
                Console.WriteLine(song);
            }
        }
    }
}