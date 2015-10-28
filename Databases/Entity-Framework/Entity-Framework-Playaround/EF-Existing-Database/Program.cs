using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EF_Existing_Database
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SampleDatabaseEntities())
            {
                //var courseToAdd = new Cours()
                //{
                //    ID = 1,
                //    Name = "Intro To Programming"
                //};

                //dbContext.Courses.Add(courseToAdd);

                //var studentToAdd = new Student()
                //{
                //    Name = "Ivankolev",
                //    Major = "CS",
                //    CourseID = 1
                //};

                //dbContext.Students.Add(studentToAdd);
                //dbContext.SaveChanges();

                var searchedCourseID = dbContext.Courses
                    .Where(cs => cs.Name.Equals("Intro To Programming"))
                    .Select(cs => cs.ID)
                    .FirstOrDefault();

                var studentInCourse = dbContext.Students
                    .Where(st => st.CourseID == searchedCourseID)
                    .Select(st => st.Name)
                    .FirstOrDefault();

                Console.WriteLine(studentInCourse);

               
            }
        }
    }
}
