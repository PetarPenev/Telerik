using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _04.RemoveExpensiveAlbums
{
    class Program
    {
        private static string filePath = "../../../catalogue.xml";

        private static CultureInfo culture = CultureInfo.GetCultureInfo("en-Us");

        static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load(filePath);

            XmlNode rootNode = document.DocumentElement;

            List<XmlNode> nodesToRemove = new List<XmlNode>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                decimal price = decimal.Parse(node["price"].InnerText, System.Globalization.NumberStyles.Currency, culture);
                if (price > 20)
                {
                    nodesToRemove.Add(node);
                }
            }

            foreach (var node in nodesToRemove)
            {
                rootNode.RemoveChild(node);
            }

            document.Save(filePath);
        }
    }
}
