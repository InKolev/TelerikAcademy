namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Test
    {
        private HashSet<Student> students;

        public Test()
        {
            this.Students = new HashSet<Student>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = (HashSet<Student>)value; }
        }
    }
}
