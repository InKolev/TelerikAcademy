namespace Exporting_CSHARP_Objects_To_XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    //[Serializable]
    public class Student
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("major")]
        public string Major { get; set; }

        [XmlElement("age")]
        public int Age { get; set; }

        [XmlAttribute("faculty")]
        public string Faculty { get; set; }

        [XmlAttribute("faculty-number")]
        public uint FacultyNumber { get; set; }

        [XmlElement(IsNullable = false)]
        public List<Course> Courses { get; set; }
    }
}
