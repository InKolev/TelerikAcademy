using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class TeachingProgram
    {
        static void Main(string[] args)
        {
            var minister = new Minister("Hwo Juan Dzya");
            var director = new Director("Sho Muo Ndzyo");
            var teacher = new Teacher("Shao Lin Ga");

            minister.Add(director);
            director.Add(teacher);
            teacher.Add(new Student("Junior Monk Sha"));
            teacher.Add(new Student("Junior Monk Pha"));
            teacher.Add(new Student("Junior Monk Ra"));
            teacher.Add(new Student("Hwa Rang Do"));
            teacher.Add(new Student("Hwa Rang Mo"));
            teacher.Add(new Student("Hwa Rang Po"));

            minister.DisplayHierarchy(0);
        }
    }
}
