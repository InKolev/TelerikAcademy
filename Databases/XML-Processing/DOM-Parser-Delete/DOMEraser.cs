using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DOM_Parser_Delete
{
    internal class DOMEraser
    {
        static void Main(string[] args)
        {
            const string fileLoadPath = "../../../XML-Processing/Catalogue/catalogue.xml";
            const string fileSavePath = "../../updatedCatalogue.xml";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileLoadPath);

            RemoveAlbumsWithPriceGreaterThan(20.00, xmlDoc);
            SaveUpdatedDocument(fileSavePath, xmlDoc);
        }

        private static void RemoveAlbumsWithPriceGreaterThan(double price, XmlDocument document)
        {
            XmlNode albums = document.DocumentElement.FirstChild;

            while(true)
            {
                var nodeIsRemoved = false;

                foreach (XmlNode album in albums.ChildNodes)
                {
                    var albumPriceAsString = album["price"].InnerText;
                    var albumPrice = double.Parse(albumPriceAsString, CultureInfo.InvariantCulture);

                    if (albumPrice > price)
                    {
                        nodeIsRemoved = true;
                        albums.RemoveChild(album);

                        Console.WriteLine("Album \"{0}\", with price {1}$ has been removed.", album["name"].InnerText, album["price"].InnerText);
                    }
                }

                if(!nodeIsRemoved)
                {
                    break;
                }
            }
            
        }

        private static void SaveUpdatedDocument(string folderPath, XmlDocument document)
        {
            document.Save(folderPath);
        }
    }
}
