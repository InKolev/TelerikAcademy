using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Text_To_XML
{
    internal class TextToXML
    {
        static void Main(string[] args)
        {
            const string fileLoadPath = "../../personData.txt";

            using (StreamReader reader = new StreamReader(fileLoadPath))
            {
                var name = reader.ReadLine();
                var phone = reader.ReadLine();
                var address = reader.ReadLine();

                var personElement = new XElement("person", 
                    new XElement("name", name), 
                    new XElement("phone", phone), 
                    new XElement("address", address));

                personElement.Save("../../person.xml");
            }

            Console.WriteLine("Person data is converted to person.xml");

        }
    }
}
