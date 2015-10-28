using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace XML_Stylesheet_Transform_CSHARP
{
    internal class XSLTransformer
    {
        private const string XsltLoadPath = "../../../XML-Stylesheet-Transform/style.xslt";
        private const string XmlLoadPath = "../../../XML-Stylesheet-Transform/catalogue.xml";
        private const string HtmlSavePath = "../../catalogue.html";

        static void Main(string[] args)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(XsltLoadPath);
            xslt.Transform(XmlLoadPath, HtmlSavePath);

            Console.WriteLine("Result saved as \"catalogue.html\" in your project folder.");
        }
    }
}
