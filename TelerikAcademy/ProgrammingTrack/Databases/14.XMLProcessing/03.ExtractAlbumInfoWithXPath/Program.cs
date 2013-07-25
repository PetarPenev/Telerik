using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _03.ExtractAlbumInfoWithXPath
{
    class Program
    {
        private static string filePath = "../../../catalogue.xml";

        static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load(filePath);

            string XPathQuery = "catalogue/album/artist";

            XmlNodeList artistNames = document.SelectNodes(XPathQuery);
            Dictionary<string, int> AlbumCountByArtist = new Dictionary<string, int>();

            foreach (XmlNode child in artistNames)
            {
                string artistName = child.InnerText;
                if (AlbumCountByArtist.Keys.Contains(artistName))
                {
                    AlbumCountByArtist[artistName] += 1;
                }
                else
                {
                    AlbumCountByArtist[artistName] = 1;
                }
            }

            foreach (var key in AlbumCountByArtist.Keys)
            {
                Console.WriteLine("{0} album(s) by {1}", AlbumCountByArtist[key], key);
            }
        }
    }
}