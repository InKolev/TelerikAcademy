namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        private HashSet<Student> students;
        private HashSet<Homework> homeworks;

        public Course()
        {
            this.Students = new HashSet<Student>();
            this.Homeworks = new HashSet<Homework>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = (HashSet<Student>)value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = (HashSet<Homework>)value; }
        }
    }
}