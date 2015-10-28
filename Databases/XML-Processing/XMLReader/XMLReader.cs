using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLReader
{
    internal class XMLReader
    {
        static void Main(string[] args)
        {
            const string fileLoadPath = "../../../XML-Processing/Catalogue/catalogue.xml";

            XmlReader reader = XmlReader.Create(fileLoadPath);

            Console.WriteLine("All songs: ");
            using(reader)
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
