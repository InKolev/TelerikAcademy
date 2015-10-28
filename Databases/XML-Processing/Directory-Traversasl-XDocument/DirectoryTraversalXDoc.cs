using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Directory_Traversasl_XDocument
{
    internal class DirectoryTraversalXDoc
    {
        static void Main()
        {
            var xmlDoc = TraverseDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            xmlDoc.Save("../../dir.xml");

            Console.WriteLine("Parsing is ready. Your result is saved as \"dir.xml\"");
        }

        static XElement TraverseDirectory(string directory)
        {
            var xmlDoc = new XElement("dir", new XAttribute("path", directory));

            foreach (var dir in Directory.GetDirectories(directory))
            {
                xmlDoc.Add(TraverseDirectory(dir));
            }

            foreach (var file in Directory.GetFiles(directory))
            {
                xmlDoc.Add(
                    new XElement("file",
                        new XAttribute("name", Path.GetFileNameWithoutExtension(file)), 
                        new XAttribute("extension", Path.GetExtension(file))));
            }

            return xmlDoc;
        }
    }
}
