using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Processing
{
    internal class XmlDOMParser
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../Catalogue/catalogue.xml");

            XmlNode xmlRoot = xmlDoc.DocumentElement;
            XmlNode albums = xmlRoot.FirstChild;

            Hashtable authorsAlbums = new Hashtable();

            foreach(XmlNode album in albums.ChildNodes)
            {
                var authorName = album["artist"].InnerText;

                if (authorsAlbums[authorName] == null)
                {
                    authorsAlbums[authorName] = 1;
                }
                else
                {
                    authorsAlbums[authorName] = int.Parse(authorsAlbums[authorName].ToString()) + 1;
                }
            }

            Console.WriteLine("DOM Parser Results: ");
            foreach(DictionaryEntry author in authorsAlbums)
            {
                Console.WriteLine("Artist {0} has {1} albums.", author.Key, author.Value);
            }
        }
    }
}
