namespace Exporting_CSHARP_Objects_To_XML
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    public class Startup
    {
        static void Main(string[] args)
        {
            using (var fileStream = File.Create(Environment.CurrentDirectory + "\\students.xml"))
            {
                var xmlSerializer = new XmlSerializer(typeof(Student));

                var subjects = new List<Subject>()
                {
                    new Subject() { Name = "Inheritance" },
                    new Subject() { Name = "Polymorphism" },
                    new Subject() { Name = "Sockets" },
                    new Subject() { Name = "Multithreading" }
                };

                var courses = new List<Course>() 
                {
                    new Course()
                    {
                        Name = "OOP WITH JAVA",
                        Hours = 30,
                        Credits = 15,
                        Subjects = subjects 
                    }
                };

                var student = new Student()
                {
                    Name = "Ivan Kolev",
                    Major = "Software Engineering",
                    Age = 21,
                    Faculty = "Computer Systems",
                    FacultyNumber = 121314,
                    Courses = courses
                };

                xmlSerializer.Serialize(fileStream, student);
            }
        }
    }
}
