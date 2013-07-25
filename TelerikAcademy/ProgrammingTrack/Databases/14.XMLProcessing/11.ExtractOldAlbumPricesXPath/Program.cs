using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _11.ExtractOldAlbumPricesXPath
{
    class Program
    {
        private static string filePath = "../../../catalogue.xml"; 

        static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load(filePath);
            int currentYear = DateTime.Now.Year;

            // Dumb way to do it.
            /*string XPathNameQuery = string.Format("/catalogue/album[year<{0}]/name", currentYear);
            string XPathPriceQuery = string.Format("/catalogue/album[year<{0}]/price", currentYear);
            string XPathYearQuery = string.Format("/catalogue/album[year<{0}]/year", currentYear);

            XmlNodeList priceNodes = document.SelectNodes(XPathPriceQuery);
            XmlNodeList nameNodes = document.SelectNodes(XPathNameQuery);
            XmlNodeList yearNodes = document.SelectNodes(XPathYearQuery);

            for (int i = 0; i < priceNodes.Count; i++)
            {
                Console.WriteLine("{0} album costs {1} and is published in {2}", nameNodes[i].InnerText, 
                    priceNodes[i].InnerText, yearNodes[i].InnerText);
            }*/

            // Right way to do it.
            string XPathQuery = string.Format("/catalogue/album[year<{0}]", currentYear - 5);
            XmlNodeList albumNodes = document.SelectNodes(XPathQuery);
            foreach (XmlNode album in albumNodes)
            {
                Console.WriteLine("{0} album costs {1} and is published in {2}", album["name"].InnerText,
                    album["price"].InnerText, album["year"].InnerText);
            }
        }
    }
}