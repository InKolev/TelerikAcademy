using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace All_Songs_XDocument_And_LINQ
{
    class XDocumentAndLinq
    {
        static void Main(string[] args)
        {
            const string fileLoadPath = "../../../XML-Processing/Catalogue/catalogue.xml";

            XDocument doc = XDocument.Load(fileLoadPath);
            XNamespace docNamespace = doc.Root.GetDefaultNamespace();

            var albums = doc
                .Element(docNamespace + "catalogue")
                .Element(docNamespace + "albums")
                .Elements(docNamespace + "album");

            var songTitles = from title in albums.Descendants(docNamespace + "title") 
                         select title.Value;

            Console.WriteLine("All songs: ");
            foreach (var songTitle in songTitles)
            {
                Console.WriteLine(songTitle);
            }
        }
    }
}
