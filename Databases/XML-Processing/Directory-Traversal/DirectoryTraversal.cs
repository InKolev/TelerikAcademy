using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Directory_Traversal
{
    internal class DirectoryTraversal
    {
        private const string OutputPath = "../../dir.xml";

        static void Main()
        {
            using (XmlTextWriter writer = new XmlTextWriter(OutputPath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 4;

                string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                writer.WriteStartDocument();
                writer.WriteStartElement("desktop");
                TraverseDirectory(directoryPath, writer);
                writer.WriteEndDocument();
            }

            Console.WriteLine("Parsing is ready. Result saved as \"dir.xml\"");
        }

        static void TraverseDirectory(string directoryPath, XmlTextWriter writer)
        {
            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("path", directory);
                TraverseDirectory(directory, writer);
                writer.WriteEndElement();
            }

            foreach (var file in Directory.GetFiles(directoryPath))
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", Path.GetFileNameWithoutExtension(file));
                writer.WriteAttributeString("extension", Path.GetExtension(file));
                writer.WriteEndElement();
            }
        }
    }
}
