using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XSD_Schema
{
    internal class Program
    {
        private const string XsdLoadPath = "../../../XML-Stylesheet-Transform/catalogue.xsd";
        private const string XsltLoadPath = "../../../XML-Stylesheet-Transform/style.xslt";
        private const string XmlLoadPath = "../../catalogue.xml";
        private const string XmlLoadPathInvalid = "../../../XML-Processing/Catalogue/invalidCatalogue.xml";

        public static void Main()
        {
            XDocument doc = XDocument.Load(XmlLoadPath);
            XDocument invalidDoc = XDocument.Load(XmlLoadPathInvalid);
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add(String.Empty, XsdLoadPath);

            PrintValidationResult(doc, schema, "catalogue.xml");
            PrintValidationResult(invalidDoc, schema, "invalidCatalogue.xml");
        }

        private static void PrintValidationResult(XDocument doc, XmlSchemaSet schema, string file)
        {
            doc.Validate(schema, (obj, ev) =>
            {
                Console.WriteLine("!!! SCHEME VALIDATION ERROR IN FILE ---> {0} !!! {1}", file, ev.Message);
            });
        }
    }
}
