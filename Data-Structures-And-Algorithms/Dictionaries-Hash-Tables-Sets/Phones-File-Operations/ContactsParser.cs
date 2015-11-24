namespace Phones_File_Operations
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class ContactsParser
    {
        public List<Contact> Start(string filePath)
        {
            return this.ReadFile(filePath);
        }

        public List<Contact> ReadFile(string filePath)
        {
            var contacts = new List<Contact>();

            using (var reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    contacts.Add(this.ConvertToContact(line));
                }
            }

            return contacts;
        }

        public Contact ConvertToContact(string line)
        {
            var contactInfo = Regex.Replace(line, @"\s+", "").Split('|');

            return new Contact()
            {
                Name = contactInfo[0].Trim(),
                City = contactInfo[1].Trim(),
                Phone = contactInfo[2].Trim()
            };
        }
    }
}