using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _12.ExtractOldAlbumPricesUsingLINQ
{
    class Program
    {
        private static string filePath = "../../../catalogue.xml"; 

        static void Main()
        {
            int currentYear = DateTime.Now.Year;

            XDocument document = XDocument.Load(filePath);
            var albums = from album in document.Descendants("album")
                         where int.Parse(album.Element("year").Value) < currentYear - 5
                         select new
                         {
                             title = album.Element("name").Value,
                             year = album.Element("year").Value,
                             price = album.Element("price").Value
                         };

            foreach (var album in albums)
            {
                Console.WriteLine("{0} album costs {1} and is published in {2}", album.title, album.price, album.year);
            }
        }
    }
}