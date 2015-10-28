using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XPath_Parser
{
    internal class XmlXPathParser
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../XML-Processing/Catalogue/albums.xml");

            XmlNode xmlRoot = xmlDoc.DocumentElement;
            string xPathQuery = "/catalogue/albums/album";

            XmlNodeList albums = xmlDoc.SelectNodes(xPathQuery);

            Hashtable authorsAlbums = new Hashtable();

            foreach (XmlNode album in albums)
            {
                var authorName = album.SelectSingleNode("artist").InnerText;

                if (authorsAlbums[authorName] == null)
                {
                    authorsAlbums[authorName] = 1;
                }
                else
                {
                    authorsAlbums[authorName] = int.Parse(authorsAlbums[authorName].ToString()) + 1;
                }
            }

            Console.WriteLine("XPath Results: ");
            foreach (DictionaryEntry author in authorsAlbums)
            {
                Console.WriteLine("Artist {0} has {1} albums.", author.Key, author.Value);
            }
        }
    }
}
