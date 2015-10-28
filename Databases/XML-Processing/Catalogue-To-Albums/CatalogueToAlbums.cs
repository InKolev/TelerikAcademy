using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Catalogue_To_Albums
{
    internal class CatalogueToAlbums
    {
        private const string InputPath = "../../../XML-Processing/Catalogue/catalogue.xml";
        private const string OutputPath = "../../albums.xml";

        static void Main(string[] args)
        {
            using (XmlTextWriter writer = new XmlTextWriter(OutputPath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;
                writer.IndentChar = ' ';
                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                using (XmlReader reader = XmlReader.Create(InputPath))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "name")
                            {
                                writer.WriteStartElement("album");
                                writer.WriteElementString("name", reader.ReadElementString());
                            }
                            else if (reader.Name == "artist")
                            {
                                writer.WriteElementString("artist", reader.ReadElementString());
                                writer.WriteEndElement();
                            }
                        }
                    }
                }

                writer.WriteEndDocument();
            }

            Console.WriteLine("Parsing is finished. Your document is ready.");
        }
    }
}
