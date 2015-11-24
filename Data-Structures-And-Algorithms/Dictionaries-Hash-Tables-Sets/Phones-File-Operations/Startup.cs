namespace Phones_File_Operations
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static List<Contact> contacts;

        static void Main(string[] args)
        {
            var parser = new ContactsParser();
            contacts = parser.Start("..\\..\\Phones.txt");
        }

        public static void Find(string name)
        {
            contacts.Where(x => x.Name.Equals(name)).Select(x => x);
        }

        public static void Find(string name, string phone)
        {

        }
    }
}