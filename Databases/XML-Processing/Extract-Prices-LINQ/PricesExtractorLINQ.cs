using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Extract_Prices_LINQ
{
    internal class PricesExtractorLINQ
    {
        private const string FileLoadPath = "../../../XML-Processing/Catalogue/albums.xml";

        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load(FileLoadPath);

            var decrement = 5;
            var currentDate = DateTime.Now;
            var pivotYear = int.Parse(currentDate.AddYears(-decrement).Year.ToString());

            var albumNames = from album in xmlDoc.Descendants("album")
                             where int.Parse(album.Element("year").Value, CultureInfo.InvariantCulture) < pivotYear
                             select album.Element("name").Value + " / "+ album.Element("price").Value + "$";

            foreach(var album in albumNames)
            {
                Console.WriteLine(album);
            }
        }
    }
}
