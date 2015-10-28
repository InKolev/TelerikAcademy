using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Extract_Prices_XPath
{
    internal class PricesExtractorXPath
    {
        private const string FileLoadPath = "../../../XML-Processing/Catalogue/albums.xml";

        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileLoadPath);

            XmlNode xmlRoot = xmlDoc.DocumentElement;

            var pivotYear = DateTime.Now.AddYears(-5).Year.ToString();
            string xPathQuery = "/catalogue/albums/album[year<" + pivotYear + "]";

            XmlNodeList albums = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode album in albums)
            {
                var albumPrice = album.SelectSingleNode("price").InnerText;
                var albumName = album.SelectSingleNode("name").InnerText;
                var albumYear = album.SelectSingleNode("year").InnerText;

                Console.WriteLine("Album {0} / Price {1}$ / Year {2}", albumName, albumPrice, albumYear);
            }

        }
    }
}
