using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace _14.XslTransformation
{
    class Program
    {
        private static string filePath = "../../../catalogue.xml";

        // Caution: the generated html is in the project folder, not in the main solution folder.
        private static string outputFilePath = "../../catalogue.html";

        private static string xslPath = "../../../catalogue.xsl";

        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xslPath);
            xslt.Transform(filePath, outputFilePath);
        }
    }
}