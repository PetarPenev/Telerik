using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _06.ExtractSongTitlesLINQ
{
    class Program
    {
        private static string filePath = "../../../catalogue.xml";

        static void Main()
        {
            XDocument document = XDocument.Load(filePath);

            var songs = from song in document.Descendants("song")
                        select song.Value;

            foreach (var item in songs)
            {
                Console.WriteLine(item);
            }
        }
    }
}