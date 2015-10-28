using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exporting_CSHARP_Objects_To_XML
{
    //[Serializable]
    public class Course
    {
        public string Name { get; set; }

        public byte Hours { get; set; }

        public byte Credits { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
